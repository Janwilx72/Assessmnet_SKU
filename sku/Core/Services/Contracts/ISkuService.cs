using System;
using sku.Core.DTOs.Requests;
using sku.Core.DTOs.Responses;

namespace sku.Core.Services.Contracts
{
	public interface ISkuService
	{
        // Using IEnumerable here as multiple Collections extend from this implementation
        // Which allows more flexibility when working with the dataset

        Task CreateProductsAsync(IEnumerable<SkuCreateRequest> requests);

        Task<IEnumerable<SkuGetResponse>> GetProductsAsync();
    }
}

