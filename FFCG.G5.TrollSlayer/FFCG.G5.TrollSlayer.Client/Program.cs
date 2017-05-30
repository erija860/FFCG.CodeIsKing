using System;
using System.Linq;
using Autofac;
using Autofac.Features.ResolveAnything;

namespace FFCG.G5.TrollSlayer.Client
{
    internal class Program
    {
        private static IContainer Container { get; set; }

        private static void Main()
        {
            Setup();
            using (var scope = Container.BeginLifetimeScope())
            {
                while (true)
                {
                    Console.WriteLine("Press Enter to start a new game...");
                    Console.ReadLine();
                    var newgame = scope.Resolve<TrollSlayerStoryGame>();
                    newgame.RunNewRound(scope.Resolve<IPlayer>());
                }
            }
        }

        private static void Setup()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Dice>().As<IDice>();
            builder.RegisterType<ConsoleLogger>().As<ILogger>();
            builder.RegisterType<PlayerStartupRule>().As<IPlayerStartupRule>();
            builder.RegisterType<TrollFactory>().As<ITrollFactory>().InstancePerDependency();
            builder.RegisterType<TrollStatsChangeRule>().As<ITrollStatsChangeRule>();
            builder.RegisterType<TrollStartupRule>().As<ITrollStartupRule>();
            builder.Register(c => new PlayerLogWrapper(new Player(c.Resolve<IPlayerStartupRule>()), c.Resolve<ILogger>())).As<IPlayer>()
                .InstancePerDependency();
            builder.RegisterSource(new AnyConcreteTypeNotAlreadyRegisteredSource());
            Container = builder.Build();
        }
    }

    public interface IDependencyResolver
    {
        T Resolve<T>() where T : class;
    }

    public class DependencyResolver : IDependencyResolver
    {
        private readonly IContainer _container;

        public DependencyResolver(IContainer container)
        {
            this._container = container;
        }

        public T Resolve<T>() where T : class
        {
            return _container.Resolve<T>();
        }
    }

    public class Dice : IDice
    {
        public int Roll(int sides)
        {
            return Enumerable.Range(1, sides).OrderBy(x => Guid.NewGuid()).First();
        }
    }

    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}