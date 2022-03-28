using System;
using DocumentFormat.OpenXml.EMMA;
using Entities.Core.Extension;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NSwag;


namespace RestApiSampleCore5
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSwaggerDocument(config =>
            {
                config.PostProcess = (doc =>
                {
                    doc.Info.Title = "TestProj Doc.";
                    doc.Info.Version = "V1";
                    doc.Info.Contact = new OpenApiContact()
                    {
                        Name = "Çahatay Özdemir",
                        Url = "",
                        Email = "cahatayozdemir@gmail.com",
                    };

                });

            });
            services.AddMvc();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            //you can close while  debugging
            //  app.ConfigureCustomExceptionMiddleware();

            app.UseHttpsRedirection();

            app.UseRouting();

            //neler yapilabilir.(evde ne yapilabilir) tokenla yetkiyi yakalmis olucaz
            app.UseAuthentication();

            //anahtar(eve giris) giris bilgileri ile login saglamak icin
            app.UseAuthorization();

            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
