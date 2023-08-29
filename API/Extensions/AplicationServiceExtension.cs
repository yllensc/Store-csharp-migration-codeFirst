using Core.Interfaces;
using Infrastructure.UnitOfWork;

namespace API.Extensions;
public static class AplicationServiceExtension
{
    //Investigar que son cors
    //Servicio, extención que debe inyectarse en el conector de dependencias
    public static void ConfigureCors(this IServiceCollection services) =>
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()  //Withorigin ("https://domini.com")
                .AllowAnyMethod()          //WithMethods ("GET", "POST")
                .AllowAnyHeader());        //WithHeaders (*accept*, "content-type)
    });

    public static void AddAplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }  
}

