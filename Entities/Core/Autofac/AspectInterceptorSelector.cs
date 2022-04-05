using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using IInterceptor = Microsoft.EntityFrameworkCore.Diagnostics.IInterceptor;

namespace EntitiesAndCore.Core.Autofac
{
    public class AspectInterceptorSelector :IInterceptorSelector
    {

        public Castle.DynamicProxy.IInterceptor[] SelectInterceptors(Type type,MethodInfo method,Castle.DynamicProxy.IInterceptor[] interceptors)
        {
            var classAttribute = type.GetCustomAttributes<MethodInterceptionBaseAttiribute>(true).ToList();
            var methodAttribute =
                type.GetMethod(method.Name).GetCustomAttributes<MethodInterceptionBaseAttiribute>(true);
            classAttribute.AddRange(methodAttribute);
            //  classAttribute.Add(new ExceptionLogAspect(typeof(DatabaseLogger)));
            //  classAttribute.Add(new ExceptionLogAspect(typeof(FileLogger)));
            return (Castle.DynamicProxy.IInterceptor[])classAttribute.OrderBy(x => x.Priority).ToArray();
        }
    }


    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method,AllowMultiple = true,Inherited = true)]
    public abstract class MethodInterceptionBaseAttiribute :Attribute, IInterceptor
    {
        virtual public void Intercept(IInvocation invocation)
        {

        }

        public int Priority { get; set; }

    }
}
