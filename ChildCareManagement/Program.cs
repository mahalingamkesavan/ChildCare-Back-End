using ChildCareAPI.CUnstomExceptionMiddleware;
using ChildCareIOC;
using NLog.Web;

namespace ChildCareAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Add services to the container.
            builder.Services.InjectDependencies(builder.Configuration);

            builder.Host.ConfigureLogging(option => { option.SetMinimumLevel(LogLevel.Debug); }).UseNLog();

            // builder.Services.AddSingleton<ImageUploadsupportclass>();

            var app = builder.Build();
            app.UseCors();
            app.UseHttpLogging();
            app.UseStaticFiles();

            app.UseSwagger();
            app.UseSwaggerUI();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.ConfigureCustomExceptionMiddleware();  // costome Middleware 
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}