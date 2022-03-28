using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using Entities.Core.Dal;
using EntitiesAndCore.Core.Dal;
using EntitiesAndCore.Core.Dal.Ef;
using EntitiesAndCore.Core.Extension.Managers;

namespace EntitiesAndCore.Core.Autofac
{
    public class AutofacBusinessModule :Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CustomerManager>().As<ICustomerService>();
            builder.RegisterType<EfCustomerDal>().As<ICustomerDal>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().EnableInterfaceInterceptors(new ProxyGenerationOptions() {
                //Selector = new AspectInterceptorSelector()

            }).SingleInstance();
        }
    }
}
