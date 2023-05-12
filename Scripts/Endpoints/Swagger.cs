using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace App.Endpoints;

public class Swagger : IEndpointDefinition {
    void IEndpointDefinition.DefineEndpoints(WebApplication app) {
        _ = app.UseSwagger();
        _ = app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "gocator-server"));
    }

    void IEndpointDefinition.DefineServices(IServiceCollection services) {
        _ = services.AddEndpointsApiExplorer();
        _ = services.AddSwaggerGen(options => options.SwaggerDoc("v1", new() { Title = "ASP.NET Core Server", Version = "v1" }));
    }
}
