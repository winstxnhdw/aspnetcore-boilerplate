using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

public interface IEndpointDefinition {
    void DefineServices(IServiceCollection services);
    void DefineEndpoints(WebApplication app);
}
