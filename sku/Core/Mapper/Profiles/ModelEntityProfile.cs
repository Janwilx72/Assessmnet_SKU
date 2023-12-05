using System;
using AutoMapper;
using sku.Core.Entities;
using sku.Core.Models;

namespace sku.Core.Mapper.Profiles
{
	public class ModelEntityProfile : Profile
	{
		public ModelEntityProfile()
		{
			CreateMap<Sku, SkuEntity>().ReverseMap();
			CreateMap<Models.Attribute, AttributeEntity>().ReverseMap();
		}
	}
}

