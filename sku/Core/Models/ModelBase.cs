using System;
namespace sku.Core.Models
{
	public class ModelBase
	{
        public Guid? Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}

