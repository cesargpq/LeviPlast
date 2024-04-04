using LeviPlast.Aplicacion.Interface;
using LeviPlast.Aplicacion.Main;
using LeviPlast.Dominio.Core;
using LeviPlast.Dominio.Interface;
using LeviPlast.Infraestructura.Data;
using LeviPlast.Infraestructura.Interface;
using LeviPlast.Infraestructura.Repository;
using LeviPlast.Transversal.Mapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;

namespace LeviPlatst.Servicio.Api
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddEndpointsApiExplorer();
            services.AddDbContext<ConnectionFactory>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("LeviPlastDB")));
            services.AddTransient<IAuthApplication, AuthApplication>();
            services.AddTransient<IAuthDomain, AuthDomain>();
            services.AddTransient<IAuthRepository, AuthRepository>();


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Servicios Rest - Validación de Contratos", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id="Bearer"
                            }
                        },
                        new string[]{}
                    }
                });
            });
            services.AddAutoMapper(x => x.AddProfile(new MappingsProfile()));
            services.AddHttpClient();
   
   

            services.AddCors(options =>
            {
                var urlList = Configuration.GetSection("AllowedOrigin").GetChildren().Select(c => c.Value).ToArray();

                options.AddDefaultPolicy(builder =>
                {
                    builder.WithOrigins(urlList).AllowAnyMethod().AllowAnyHeader();
                });
            });

        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseHttpsRedirection();
            app.UseCors();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(options =>
            {
                options.MapControllers();
            });
        }
    }
}
