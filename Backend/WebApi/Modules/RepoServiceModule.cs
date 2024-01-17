using System.Reflection;
using Autofac;
using DataAccessLayer.Concrete;
using Module = Autofac.Module;

namespace WebApi.Modules;

public class RepoServiceModule : Module
{
    
    /*protected override void load(ContainerBuilder builder)
    {
        var apiAssembly = Assembly.GetExecutingAssembly();

        builder.RegisterAssemblyTypes(apiAssembly)
            .Where(x => x.Name.EndsWith("Dal"))
            .AsImplementedInterfaces()
            .InstancePerLifetimeScope();
        
        builder.RegisterAssemblyTypes(apiAssembly)
            .Where(x => x.Name.EndsWith("service"))
            .AsImplementedInterfaces()
            .InstancePerLifetimeScope();
    }*/
    
}