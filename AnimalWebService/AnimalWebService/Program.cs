
using AnimalWebService.Repositories;
using AnimalWebService.Services;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddScoped<IAnimalsRepository, AnimalsRepository>();
        builder.Services.AddScoped<IAnimalsService, AnimalsService>();
        builder.Services.AddTransient<IOrderingService, OrderingService>();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddControllers();
        
        var app = builder.Build();
        app.UseHttpsRedirection();
        app.MapControllers();
        app.UseSwagger();
        app.UseSwaggerUI();
        
        app.Run();
    }
}