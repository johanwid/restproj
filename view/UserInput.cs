using System;

namespace view
{

    class UserInput
    {
        public static void Main() 
        {
            string input;

            Console.WriteLine("Input ticker: ");
            input = Console.ReadLine();
            Console.WriteLine("Ticker selected: " + input);
        }
    }
}
