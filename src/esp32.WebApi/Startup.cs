using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using esp32.Business;
using esp32.DA;
using esp32.Mapper;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.IO;
using System;
using esp32.Business.Abstraction.interfaces;
using esp32.DA.Abstraction.interfaces;

namespace esp32.WebApi
{
    public class Startup
    {

        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddSwaggerGen(options => {
                options.SwaggerDoc("v1", new OpenApiInfo {
                    Title = "API ESP32",
                    Version = "V1",
                    Description = "API em C# para receber informações do microcontrolador ESP32 e enviar para UI em Angular"
                });
            });

            services.AddCors(options => {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                    builder => {
                        builder.WithOrigins("http://localhost:4200")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                    });
            });

            services.AddEntityFrameworkNpgsql().AddDbContext<esp32Context>(options => {
                options.UseNpgsql(Configuration.GetConnectionString("Esp32"));
                options.UseLazyLoadingProxies();
            });

            services.AddAutoMapper(typeof(Mappers));
            services.AddControllers();
            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IBalancaService, BalancaService>();
            services.AddScoped<IEspService, EspService>();

            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IBalancaRepository, BalancaRepository>();
            services.AddScoped<IHistoricoProdutoRepository, HistoricoProdutoRepository>();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if(env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });

            app.UseSwagger(c => {
                c.SerializeAsV2 = true;
            });

            app.UseSwaggerUI(options => {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Esp32");
            });
        }
    }
}
