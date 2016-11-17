using FFCG.G5.Painter.InputOutput;
using TinyIoC;

namespace FFCG.G5.Painter.GUI
{
    internal class Program
    {
        public static void Main()
        {
            var container = TinyIoCContainer.Current;

            container.Register<IOutput, OutputStream>();
            container.Register<IUserInput, UserInputStream>();
            var paintShop = container.Resolve<PaintShop>();

            while (true)
                paintShop.MakeBusiness();
            // ReSharper disable once FunctionNeverReturns
        }
    }
}