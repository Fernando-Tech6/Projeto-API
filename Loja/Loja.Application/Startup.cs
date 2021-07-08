using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Loja.Data.Context;
using Loja.CrossCutting.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using Loja.CrossCutting.JwtInjection;

namespace Application
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

               var conexao = Configuration.GetConnectionString("Default");
               services.AddDbContext<ApplicationDbContext>(op => op.UseMySql(conexao));


            /*injeção de dependencia do service e repository*/
            ConfigureService.ConfigureDependenciesService(services);
            ConfigureRepository.ConfigureDependenciesRepository(services);


            /*Para evitar o loop e a exceção do tipo JsonException. Foi adicionado o pacote
            aspnetcore.mvc.Newtonsoftjson e valores nulos*/
            services.AddControllers().AddNewtonsoftJson(op =>
            {
                op.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                 op.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore; /*Usado para ignorar valores null ao exibir json*/
            });

            

            /*Adicionar Swagger*/
            services.AddSwaggerGen(t =>
            {
                t.SwaggerDoc("v1",new OpenApiInfo
                {
                    /*documentação*/
                    Version = "v1",
                    Title = "Projeto API - Loja",
                    Description = "Projeto Start - API",
                    TermsOfService = new Uri("https://blog.gft.com/br/"),

                    Contact = new OpenApiContact
                    { /*Contato para documentação*/
                        Name = "Fernando Vieira",
                        Email = "fernando.vieira@gft.com",
                        Url = new Uri("https://git.gft.com/fovr")
                    }
                });

                 /*Swagger + Authentication
                 */
                  t.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                 {
                     Name = "Authorization",
                     In = ParameterLocation.Header,
                     Type = SecuritySchemeType.ApiKey,
                     Scheme = "Bearer"
                 });
                 t.AddSecurityRequirement(new OpenApiSecurityRequirement
                 {
                     {
                         new OpenApiSecurityScheme
                         {
                             Reference = new OpenApiReference
                             {
                                 Type = ReferenceType.SecurityScheme,
                                 Id = "Bearer"
                             }
                         },
                         Array.Empty<string>()
                     }
                 });
            });

            /*Testando Jwt por Injeção*/
            ConfigureJwt.JwtDependecy(services);        
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ApplicationDbContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            /*Adicionando swagger*/
            app.UseSwagger();
            app.UseSwaggerUI(t => 
            {
                t.SwaggerEndpoint("/swagger/v1/swagger.json", "Projeto API");
                t.RoutePrefix = string.Empty;  /*com o routeprefix vazio irá abrir diretamente no swagger*/
            });

            app.UseHttpsRedirection();


            app.UseRouting();

             app.UseAuthentication();  //Autenticando a criação de token.


            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            InicializaDb.Initialize(context);
        }
    }
}
