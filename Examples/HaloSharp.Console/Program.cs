using Autofac;
using HaloSharp.Console.Infrastructure;

namespace HaloSharp.Console
{
    internal static class Program
    {
        private static void Main()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new ApplicationModule());
            builder.RegisterModule(new HaloSharpModule());
            var container = builder.Build();

            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IApplication>();

                app.Run();
            }
        }
    }
}
