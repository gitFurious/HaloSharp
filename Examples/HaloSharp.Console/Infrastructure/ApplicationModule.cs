using Autofac;

namespace HaloSharp.Console.Infrastructure
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Application>()
                .As<IApplication>()
                .InstancePerDependency();
        }
    }
}
