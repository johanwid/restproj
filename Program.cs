using System;
using controller;

namespace restproj
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Running program.");

            Controller controller = new Controller();
            controller.Start();
        }
    }
}
