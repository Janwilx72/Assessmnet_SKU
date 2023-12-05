using System;
using sku.Core.DTOs.Requests;
using sku.Core.DTOs.Responses;

namespace sku.Core.Repositories.Contracts
{
	public interface ISkuRepository
	{
        Task CreateSkuWithAttributesAsync(IEnumerable<SkuCreateRequest> request);

        Task<IEnumerable<SkuGetResponse>> GetProductsAsync();
    }
}

