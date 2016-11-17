using System;
using System.Diagnostics;
using System.Drawing;

namespace FFCG.G5.Painter.InputOutput
{
    public interface IOutput
    {
        void Print(string message);
        void Print(string message, Color color);
    }

    public class OutputStream : IOutput
    {
        public void Print(string message)
        {
            Console.WriteLine(message);
        }

        public void Print(string message, Color color)
        {
            Console.ForegroundColor = GetColor(color); //ConsoleColor.White;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        private static ConsoleColor GetColor(Color color)
        {
            if (color == Color.Red)
                return ConsoleColor.Red;
            if (color == Color.Blue)
                return ConsoleColor.Blue;
            if (color == Color.Green)
                return ConsoleColor.Green;
            return ConsoleColor.Magenta;
        }
    }

    public class TestOutput : IOutput
    {
        public string LastMessage;

        public void Print(string message)
        {
            LastMessage = message;
            Trace.WriteLine(message);
        }

        public void Print(string message, Color color)
        {
            LastMessage = message;
            Trace.WriteLine(message);
        }
    }

    public static class ColorExtention
    {
        public static string GetString(this Color color)
        {
            if (color == Color.Red)
                return "Red";
            if (color == Color.Blue)
                return "Blue";
            if (color == Color.Green)
                return "Green";
            return color == Color.Pink ? "Pink" : color.ToString();
        }
    }
}