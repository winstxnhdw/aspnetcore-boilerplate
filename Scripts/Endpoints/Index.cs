using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace App.Endpoints;

public class Gocator : Connection, IEndpointDefinition {
    internal IResult Index() {
        return Results.Ok("Hello World!");
    }

    public void DefineEndpoints(WebApplication app) {
        const string BaseRoute = "/";
        _ = app.MapGet(BaseRoute, this.Index);
    }

    public void DefineServices(IServiceCollection services) {
        _ = services.AddSingleton<Gocator>();
        _ = services.AddHttpClient();
    }
}
