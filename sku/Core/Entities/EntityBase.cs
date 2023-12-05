using System;
using System.ComponentModel.DataAnnotations;

namespace sku.Core.Entities
{
	public class EntityBase
	{
		[Required]
		public Guid Id { get; set; }
		public bool IsDeleted { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime? UpdatedDate { get; set; }
	}
}

