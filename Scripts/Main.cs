#pragma warning disable CA1852

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointDefinitions();

WebApplication app = builder.Build();
app.UsePathBase("/api");
app.UseHttpsRedirection();
app.UseRouting();
app.UseEndpointDefinitions();
app.UseAuthorization();
app.MapControllers();
app.Run();
