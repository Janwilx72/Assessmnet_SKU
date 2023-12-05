using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace sku.Core.Entities
{
	public class SkuEntity : EntityBase
	{
		public AttributeEntity Attribute { get; set; }
	}
}

