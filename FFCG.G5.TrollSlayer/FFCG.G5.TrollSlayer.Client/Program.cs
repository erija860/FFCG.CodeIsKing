using System;
using System.Linq;
using Autofac;
using Autofac.Features.ResolveAnything;
using FFCG.G5.TrollSlayer.Characters;
using FFCG.G5.TrollSlayer.GameEngine;
using FFCG.G5.TrollSlayer.Interfaces;
using FFCG.G5.TrollSlayer.Rules;

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
                    var game = scope.Resolve<TrollSlayerStoryGame>();
                    game.Run();
                }
            }
        }

        private static void Setup()
        {
            var builder = new ContainerBuilder();

            //Utils
            builder.RegisterType<Dice>().As<IDice>();
            builder.RegisterType<ConsoleLogger>().As<ILogger>();

            //Characters
            builder.RegisterType<TrollFactory>().As<ITrollFactory>().InstancePerDependency();
            builder.RegisterType<Player>().As<IPlayer>().InstancePerDependency();

            //Rules
            builder.RegisterType<TrollStatsChangeRule>().As<ITrollStatsChangeRule>();
            builder.RegisterType<TrollStartupRule>().As<ITrollStartupRule>();
            builder.RegisterType<PlayerEquipmentRule>().As<IPlayerEquipmentRule>();
            builder.RegisterType<CharacterCriticalStrikeRule>().As<ICharacterCriticalStrikeRule>();

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
            _container = container;
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