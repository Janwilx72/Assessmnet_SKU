using System;
namespace sku.Core.DTOs.Responses
{
	public class SkuGetResponse
	{
        public Guid SkuId { get; set; }
        public sku.Core.Models.Attribute Attribute { get; set; }
    }
}

