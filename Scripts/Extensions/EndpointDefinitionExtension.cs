using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

public static class EndpointDefinitionExtensions {
    public static void AddEndpointDefinitions(this IServiceCollection services) {
        List<IEndpointDefinition> definitions =
            typeof(Program).Assembly
                           .GetExportedTypes()
                           .Where(type => typeof(IEndpointDefinition).IsAssignableFrom(type) && !type.IsAbstract)
                           .Select(Activator.CreateInstance)
                           .Cast<IEndpointDefinition>()
                           .ToList();

        definitions.ForEach(definition => definition.DefineServices(services));
        _ = services.AddSingleton(definitions);
    }

    public static void UseEndpointDefinitions(this WebApplication app) {
        app.Services.GetRequiredService<List<IEndpointDefinition>>()
                    .ForEach(definition => definition.DefineEndpoints(app));
    }
}
