using PlatePalApi.Models;
using PlatePalApi.Services;

var builder = WebApplication.CreateBuilder(args);

// services to the container.
builder.Services.Configure<NumberPlateDatabaseSettings>(
    builder.Configuration.GetSection("platePatrolDatabase"));

builder.Services.AddSingleton<numPlateService>();
builder.Services.AddControllers()
    .AddJsonOptions(
        options => options.JsonSerializerOptions.PropertyNamingPolicy = null);