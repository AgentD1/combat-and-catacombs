using System;
using System.Threading;

namespace Combat_and_Catacombs {
    class Game {
        static void Main(string[] args) {
            bool quitting = false;

            while (!quitting) {
                string input = Console.ReadLine();
                quitting = CommandParser.Parse(input);
            }
            Console.WriteLine("Quitting...");
            Thread.Sleep(2000);
        }
    }
}
