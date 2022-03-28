using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Entities.Concrete.EntityFrameWork.Context;
using EntitiesAndCore.Core.Autofac;
using EntitiesAndCore.Core.Dal;
using EntitiesAndCore.Core.Extension.Managers;

namespace RestApiSampleCore5
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureContainer<ContainerBuilder>(builder =>
                {
                    
                    builder.RegisterModule(new AutofacBusinessModule());
                    builder.RegisterType<ExampleDbContext>().AsSelf().As<ExampleDbContext>().InstancePerLifetimeScope();
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
