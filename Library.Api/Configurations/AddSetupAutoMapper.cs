using AutoMapper;
using Library.Api.Configurations;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Library.Api.Configurations
{
    public static class AddAutoMapperSetup
    {
        public static void AddSetupAutoMapper(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper();

            AutoMapperConfig.RegisterMappings();
        }
    }
}
