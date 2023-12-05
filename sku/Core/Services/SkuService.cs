using System;
using sku.Core.DTOs.Requests;
using sku.Core.DTOs.Responses;
using sku.Core.Repositories.Contracts;
using sku.Core.Services.Contracts;

namespace sku.Core.Services
{
	// Service Class to house business logic. Controller should not directly speak to Repositories. The Controller must access the database repositories
	// Through the service classes
	public class SkuService : ISkuService
	{
		private readonly ISkuRepository _repository;

		public SkuService(ISkuRepository repository)
		{
			_repository = repository;
		}

		public async Task CreateProductsAsync(IEnumerable<SkuCreateRequest> requests)
		{
			await _repository.CreateSkuWithAttributesAsync(requests);
		}

        public async Task<IEnumerable<SkuGetResponse>> GetProductsAsync()
        {
			return await _repository.GetProductsAsync();
        }
    }
}

