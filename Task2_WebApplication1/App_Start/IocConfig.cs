using System.Web.Http;
using Business.Repositories;
using Ninject;
using Ninject.Web.WebApi;

namespace Task2_WebApplication1.App_Start
{
    public class IocConfig
    {
        public static void RegisterIoc(HttpConfiguration config)
        {
            var kernel = new StandardKernel();

            kernel.Bind<IUnitOfWork>().To<UnitOfWork>();

            config.DependencyResolver = new NinjectDependencyResolver(kernel);
        }
    }
}