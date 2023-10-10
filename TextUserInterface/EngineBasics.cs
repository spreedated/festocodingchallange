using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Crayon.Output;

namespace TextUserInterface
{
    public static class EngineBasics
    {
        public static void DisplayProgramHeader(string heading)
        {
            StringBuilder sb = new();
            int spaces = Convert.ToInt32(Math.Ceiling((Console.BufferWidth / 2) - (double)(heading.Length / 2)));
            sb.Append($"▐{new string('█', Console.BufferWidth - 2)}▌\n");
            sb.Append($"{new string('█', (spaces - 1) / 2)}▌{new string(' ', spaces / 2)}{heading}{new string(' ', spaces / 2)}▐{new string('█', (spaces - 3) / 2)}\n");
            sb.Append($"{new string('█', (spaces - 1) / 2)}▌{new string(' ', spaces / 2)}{new string('▀', heading.Length)}{new string(' ', spaces / 2)}▐{new string('█', (spaces - 3) / 2)}\n");
            sb.Append($"▐{new string('█', Console.BufferWidth - 2)}▌\n");
            sb.Append($"\n\n");

            DisplayColoredBlocks(sb);

            Console.ResetColor();
        }

        private static void DisplayColoredBlocks(StringBuilder sb)
        {
            foreach (char c in sb.ToString())
            {
                if (c == '█' || c == '▐' || c == '▌')
                {
                    Random rnd = new(BitConverter.ToInt32(Guid.NewGuid().ToByteArray()));
                    Console.ForegroundColor = (ConsoleColor)rnd.Next(0, Enum.GetValues(typeof(ConsoleColor)).Cast<int>().Max());
                    Console.Write(c);
                    continue;
                }
                if (c == '▀' || c == ' ')
                {
                    Console.Write(c);
                    continue;
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(c);
            }
        }

        /// <summary>
        /// Changes the Foreground Color and resets it afterwards
        /// </summary>
        /// <param name="color"></param>
        /// <param name="text"></param>
        /// <param name="newline"></param>
        public static void WriteColor(ConsoleColor color, string text, bool newline = true, bool bold = false)
        {
            Console.ForegroundColor = color;
            Console.Write($"{(bold ? Bold(text) : text)}{(newline ? "\n" : "")}");
            Console.ResetColor();
        }

        public static void DisplaySolutionEnd()
        {
            StringBuilder sb = new();

            sb.Append("\n\n");
            sb.Append($"{new string(' ', Console.BufferWidth / 4)}▐{new string('█', (Console.BufferWidth - 2) / 2)}▌\n");
            sb.Append("\tPress any key to return ...");

            DisplayColoredBlocks(sb);
            
            Console.ReadKey();
        }

        public static void DisplayEnd()
        {
            StringBuilder sb = new();
            string text = "Thank you for using!";

            sb.Append("\n\n\n");
            sb.Append($"{new string(' ', Console.BufferWidth / 4)}▐{new string('█', (Console.BufferWidth - 2) / 2)}▌\n");
            sb.Append($"{new string(' ', Console.BufferWidth / 4)}▐{new string('█', (Console.BufferWidth - 2) / 2)}▌\n");
            sb.Append($"{new string(' ', Console.BufferWidth / 4)}▐{new string('█', (Console.BufferWidth - 2) / 16)}▌{new string(' ', ((Console.BufferWidth) / 16) + (text.Length / 2) - 4)}{text}{new string(' ', ((Console.BufferWidth) / 16) + 4)}▐{new string('█', (Console.BufferWidth - 2) / 16)}▌\n");
            sb.Append($"{new string(' ', Console.BufferWidth / 4)}▐{new string('█', (Console.BufferWidth - 2) / 2)}▌\n");
            sb.Append($"{new string(' ', Console.BufferWidth / 4)}▐{new string('█', (Console.BufferWidth - 2) / 2)}▌\n");
            sb.Append($"{new string('\n',4)}");

            Console.Write(sb.ToString());

            Environment.Exit(0);
        }
    }
}
