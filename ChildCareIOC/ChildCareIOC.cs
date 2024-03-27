using AutoMapper;
using ChildCareBAL.Helper;
using ChildCareBAL.Implimentation;
using ChildCareBAL.Iservicess;
using ChildCareDAL.DBcontext;
using ChildCareDAL.Repositories.Implementation;
using ChildCareDAL.Repositories.IRepositories;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace ChildCareIOC
{
    public static class DependencyInjection
    {
        public static void InjectDependencies(this IServiceCollection services, IConfiguration Configuration)
        {   // Add services to the container.
            services.AddControllers();

            services.AddHttpLogging(option =>
            {
                option.LoggingFields = HttpLoggingFields.All;
            }); // use to get the all request and response  in console

            services.AddMediatR(typeof(ApplicationDbContext).Assembly);

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddSwaggerGen();
            services.AddScoped<IParentBAL, ParentBAL>(); services.AddScoped<IChildBAL, ChildBAL>(); services.AddScoped<IEnrollmentBAL, EnrollmentBAL>();
            services.AddScoped<IFileBAL, FileBAL>(); services.AddScoped<IFileDAL, FileDAL>();
            services.AddScoped<IClassBAL, ClassBAL>(); services.AddScoped<IClassDAL, ClassDAL>();
            services.AddScoped<ISlotBAL, SlotBAL>(); services.AddScoped<ISlotDAL, SlotDAL>();
            services.AddScoped<IParentDAL, ParentDAL>(); services.AddScoped<IChildDAL, ChildDAL>(); services.AddScoped<IEntrollmentDAL, EntrollmentDAL>();

            services.AddAutoMapper(typeof(ApplicationMapper));

           // var provider = new PhysicalFileProvider("D:\\Entity Framework\\ChildCareManagement\\ChildCareManagement\\wwwroot\\image");

            //services.AddSingleton<IFileProvider>(provider);


            services.AddDbContext<ApplicationDbContext>
                (
                    x =>
                    {
                        x.UseMySql(Configuration.GetConnectionString("ConStr"), ServerVersion.Parse("10.4.24-mariadb"));
                        x.EnableDetailedErrors();
                        x.EnableSensitiveDataLogging();
                    }
                );

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

            services.AddEndpointsApiExplorer();
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
            // add swagger and athentication in swagger uses
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
