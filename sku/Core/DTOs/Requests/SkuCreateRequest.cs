using System;
namespace sku.Core.DTOs.Requests
{
	public class SkuCreateRequest
	{
		public Guid? SkuId { get; set; }
		public sku.Core.Models.Attribute Attribute { get; set; }
	}
}

