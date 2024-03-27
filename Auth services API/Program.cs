#nullable disable
using AuthServicesAPI.ExceptionMiddleware;
using AuthServicesIOC;
using NLog.Web;

#nullable disable
namespace AuthServicesAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.InjectDependencies(builder.Configuration);
            builder.Host.ConfigureLogging(option => { option.SetMinimumLevel(LogLevel.Debug); }).UseNLog();
            var app = builder.Build();
            app.UseCors();
            app.UseHttpLogging();
            app.UseSwagger();
            app.UseSwaggerUI();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.ConfigureCustomExceptionMiddleware(); // Custome Middleware

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}