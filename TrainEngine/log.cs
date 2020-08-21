using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainEngine.TrainEngine
{
    public static class Log {

        public static void Normal(string msg) { Console.WriteLine( $"[MSG] - {msg} " );  }
        public static void Warning(string msg) { Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine($"[WARNING] - {msg} "); Console.ForegroundColor = ConsoleColor.White; }
        public static void Info(string msg) { Console.ForegroundColor = ConsoleColor.Magenta; Console.WriteLine($"[INFO] - {msg} "); Console.ForegroundColor = ConsoleColor.White; }
        public static void Error(string msg) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine($"[ERROR] - {msg} "); Console.ForegroundColor = ConsoleColor.White; }
    }
}
