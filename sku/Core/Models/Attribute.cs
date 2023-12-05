using System;
using System.ComponentModel.DataAnnotations;

namespace sku.Core.Models
{
	public class Attribute : ModelBase
	{
        public string Size { get; set; }
        public string Grams { get; set; }
        public string Foo { get; set; }
        public Guid? SkuId { get; set; }
    }
}

