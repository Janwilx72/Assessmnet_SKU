using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sku.Core.Entities
{
	public class AttributeEntity : EntityBase
	{
		public string Size { get; set; }
		public string Grams { get; set; }
		public string Foo { get; set; }

		[Required]
		public Guid SkuId { get; set; }

		[ForeignKey(nameof(SkuId))]
		public SkuEntity Sku { get; set; }
	}
}

