using StockService.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configuration(builder.Configuration);

builder.BuildAndConfigureRequestPipeline().Run();
