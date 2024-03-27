using AuthServicesBAL.Implementations;
using AuthServicesBAL.IServices;
using AuthservicesDAL.DataContext;
using AuthservicesDAL.Repositories.Implementation;
using AuthservicesDAL.Repositories.IRepositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;


namespace AuthServicesIOC
{
    public static class DependencyInjection
    {
        public static void InjectDependencies(this IServiceCollection services, IConfiguration Configuration)
        {
            // Add services to the container.
            services.AddControllers();
            // use to get the all request and response  in console

            services.AddHttpLogging(option =>
            {
                option.LoggingFields = Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.All;
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            //  builder.Services.InjectDependenciesAndJwt(builder.Configuration);
            services.AddEndpointsApiExplorer();
            //DI
            services.AddScoped<IUserRepository, UserRepository>(); services.AddScoped<IUserService, UserService>();

            services.AddDbContext<DtContext>(x => x.UseMySql(Configuration.GetConnectionString("ConStr"), ServerVersion.Parse("10.4.24-mariadb")));
            // services.AddDbContext<DtContext>(x => x.UseSqlServer(Configuration.GetConnectionString("ConStr2")));
            // react using Cors
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(o =>
                {
                    o.AllowAnyHeader();
                    o.AllowAnyOrigin();
                    o.AllowAnyMethod();
                });
            });

            // For Identity  
            services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<DtContext>()
            .AddDefaultTokenProviders();

            // Adding Authentication  
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })

            // Adding Jwt Bearer  
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = Configuration["JWT:ValidAudience"],
                    ValidIssuer = Configuration["JWT:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Secret"]))
                };
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "AuthServices",
                    Version = "v1"
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Autheorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Here Enter Token bearer formate like Bearer[space] token"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                     { { new OpenApiSecurityScheme
                           {
                            Reference = new OpenApiReference
                             {
                             Type = ReferenceType.SecurityScheme,
                             Id = "Bearer"
                             }
                     },
                     new string[] { }
                    }
                 });
            });

        }
    }
}
