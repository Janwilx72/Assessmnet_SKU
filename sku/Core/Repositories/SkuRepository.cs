using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using sku.Core.Database;
using sku.Core.DTOs.Requests;
using sku.Core.DTOs.Responses;
using sku.Core.Entities;
using sku.Core.Repositories.Contracts;

namespace sku.Core.Repositories
{
	public class SkuRepository : ISkuRepository
	{
		private readonly DatabaseContext _databaseContext;
		private readonly IMapper _mapper;

		public SkuRepository(DatabaseContext databaseContext, IMapper mapper)
		{
			_databaseContext = databaseContext;
			_mapper = mapper;
		}

		public async Task CreateSkuWithAttributesAsync(IEnumerable<SkuCreateRequest> requests)
		{
			using (var transaction = _databaseContext.Database.BeginTransactionAsync())
			{
				try
				{
					foreach (var request in requests)
					{
                        // Not done in Parallel due to ForeignKey constraint
                        var skuId = await CreateSkuAsync(request.SkuId);
                        CreateAttributesAsync(skuId, request.Attribute);
                    }
					
                    await _databaseContext.SaveChangesAsync().ConfigureAwait(false);
                    await transaction.Result.CommitAsync();
				}
				catch(Exception e)
				{
					await transaction.Result.RollbackAsync();
					throw;
				}
			}
		}

		private async Task<Guid> CreateSkuAsync(Guid? skuId)
		{
			if(skuId != null)
			{
				var dbItem = await _databaseContext.Set<SkuEntity>().FindAsync(skuId.Value).ConfigureAwait(false);
				if (dbItem != null)
					throw new Exception("Sku already exists");
			}

			var skuEntity = new SkuEntity();
			skuEntity.Id = skuId ?? Guid.NewGuid();
			skuEntity.IsDeleted = false;
			skuEntity.CreatedDate = DateTime.UtcNow;

			_databaseContext.Set<SkuEntity>().Add(skuEntity);
			return skuEntity.Id;
		}

		private void CreateAttributesAsync(Guid skuId, sku.Core.Models.Attribute attribute)
		{
			var entity = _mapper.Map<AttributeEntity>(attribute);
			entity.Id = attribute.Id ?? Guid.NewGuid();
			entity.IsDeleted = false;
			entity.CreatedDate = DateTime.UtcNow;
			entity.SkuId = skuId;

            _databaseContext.Set<AttributeEntity>().Add(entity);
        }

        public async Task<IEnumerable<SkuGetResponse>> GetProductsAsync()
        {
			var query = _databaseContext.Attributes.Where(x => !x.IsDeleted)
							.Select(t => new SkuGetResponse
							{
								SkuId = t.SkuId,
								Attribute = new Models.Attribute
								{
									Id = t.Id,
									Size = t.Size,
									Foo = t.Foo,
									Grams = t.Grams,
									CreatedDate = t.CreatedDate,
									UpdatedDate = t.UpdatedDate,
									SkuId = t.SkuId
								}
							});

			var results = await query.ToListAsync();
			return results;
        }
    }
}

