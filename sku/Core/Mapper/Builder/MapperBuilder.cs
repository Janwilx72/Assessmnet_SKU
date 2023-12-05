using System;
using AutoMapper;
using sku.Core.Mapper.Profiles;

namespace sku.Core.Mapper.Builder
{
	public class MapperBuilder
	{
        private static readonly Lazy<AutoMapper.IConfigurationProvider> _configuration =
            new Lazy<AutoMapper.IConfigurationProvider>(DefaultConfiguration, LazyThreadSafetyMode.ExecutionAndPublication);

        private static readonly Lazy<IMapper> _mapper =
                new Lazy<IMapper>(DefaultMapper, LazyThreadSafetyMode.ExecutionAndPublication);

        public static IMapper Mapper
        {
            get
            {
                return _mapper.Value;
            }
        }

        public static AutoMapper.IConfigurationProvider Configuration
        {
            get
            {
                return _configuration.Value;
            }
        }

        private static AutoMapper.IConfigurationProvider DefaultConfiguration()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ModelEntityProfile>();
            });

            return configuration;
        }

        private static IMapper DefaultMapper()
        {
            var mapper = Configuration.CreateMapper();
            return mapper;
        }
    }
}

