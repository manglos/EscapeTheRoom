using System;

namespace EscapeTheRoomConsole
{
    public static class ColorfulConsole
    {
        public static void WriteLine(string text, ConsoleColor? color = null)
        {
            if (color == null)
            {
                color = ConsoleColor.White;
            }

            var originalColor = Console.ForegroundColor;
            Console.ForegroundColor = color.Value;
            Console.WriteLine(text);
            Console.ForegroundColor = originalColor;
        }

        public static void Write(char character, ConsoleColor color)
        {
            var originalColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.Write(character);
            Console.ForegroundColor = originalColor;
        }

        public static void Write(string v)
        {
            Console.Write(v);
        }

        public static void Clear()
        {
            Console.Clear();
        }

        public static string ReadLine()
        {
            return Console.ReadLine();
        }

        internal static void WriteAscii(string text)
        {
            Colorful.Console.WriteAscii(text);
        }

        internal static void WriteLine()
        {
            Console.WriteLine();
        }
    }
}
