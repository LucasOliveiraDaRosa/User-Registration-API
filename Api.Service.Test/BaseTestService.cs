using AutoMapper;
using CrossCuting.Mappings;
using System;

namespace Api.Service.Test
{
    public abstract class BaseTestService
    {

        public IMapper mapper { get; set; }

        public BaseTestService()
        {
            mapper = new AutoMapperFixture().GetMapper();
        }

        public class AutoMapperFixture : IDisposable
        {
            public IMapper GetMapper()
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile(new ModelToEntityProfile());
                    cfg.AddProfile(new DTOToModelProfile());
                    cfg.AddProfile(new EntityToDTOProfile());
                });

                return config.CreateMapper();
            }
            public void Dispose()
            {
            }
        }
    }
}
