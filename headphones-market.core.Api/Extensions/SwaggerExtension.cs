﻿using Microsoft.OpenApi.Models;

namespace headphones_market.core.Api.Extensions
{
 public static class SwaggerExtension
{
    public static IServiceCollection ConfigureSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(swagger =>
        {
            swagger.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "API",
                Description = ".NET 8 Web API"
            });
        });
        return services;
    }
}
}
