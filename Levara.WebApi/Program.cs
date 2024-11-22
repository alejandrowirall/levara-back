using Levara.Infrastructure;
using Levara.WebApi.Infrastructure.Middlewares;
using Levara.WebApi.Infrastructure.Security;
using Microsoft.OpenApi.Models;
using Serilog;

const string AllowAnyOrigin = "_allowAnyOrigin";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLevaraSerilog(builder.Configuration);

try
{

    builder.Services.AddCors(options =>
    {
        options.AddPolicy(AllowAnyOrigin,
            builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            });
    });

    // Add services to the container.

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddAWSLambdaHosting(LambdaEventSource.HttpApi);
    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Levara WebApi", Version = "v1" });

        // Definir el esquema de seguridad
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Description = "JWT Authorization header using the Bearer scheme. Example: 'Bearer {token}'",
            Name = "Authorization",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer"
        });

        // Requiere el token para todas las operaciones
        c.AddSecurityRequirement(new OpenApiSecurityRequirement()
        {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "Bearer",
                Name = "Authorization",
                In = ParameterLocation.Header,
                BearerFormat = "JWT" // Esto es opcional, pero puede indicar que se espera un JWT
            },
            new List<string>()
        }
        });
    }); ;

    //builder.Services.AddHttpContextAccessor();

    builder.Services.AddServices(builder.Configuration);

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        //app.UseSwagger();
        //app.UseSwaggerUI();
    }

    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseHttpsRedirection();

    app.UseAuthentication();

    app.UseAuthorization();

    app.UseCors(AllowAnyOrigin);

    app.UseLevaraLogger();
    app.UseLevaraException();

    app.MapControllers();


    Log.Information("Starting web host");
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}

