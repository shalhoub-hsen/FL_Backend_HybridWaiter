using AutoMapper;
using HybridWaiterServiceLayer.Mapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HybridWaiterServiceLayer.Infrastructure
{
    
    public static class CustomAutoMapper
    {
        public static void AddCustomConfiguredAutoMapper(this IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperClient());
                cfg.AddProfile(new AutoMapperFeedBack());
                cfg.AddProfile(new AutoMapperFoodMenu());
                cfg.AddProfile(new AutoMapperPosition());
                cfg.AddProfile(new AutoMapperServiceList());
                cfg.AddProfile(new AutoMapperTeamMember());
                cfg.AddProfile(new AutoMapperLookupValue());
                cfg.AddProfile(new AutoMapperBank());
                cfg.AddProfile(new AutoMapperOrder());
                cfg.AddProfile(new AutoMapperOrderDetail());
                cfg.AddProfile(new AutoMapperBooking());




            });
            IMapper mapper = config.CreateMapper();

            services.AddSingleton(mapper);
        }
    }
}
