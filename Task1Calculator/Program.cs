using System;
using Microsoft.VisualBasic.CompilerServices;

namespace Calculator
{
    class Program
    {
        private static char x;
        internal static void EndingLoop()
        {
            while (x != 'x' || x != 'X')
            {
                x = Console.ReadKey().KeyChar;
                if (x == 'x' || x == 'X')
                {
                    Console.Clear();
                    Console.WriteLine("Goodbye!");
                    Environment.Exit(0);
                }

                break;
            }
        }
        private static void Main()
        {
            string inputStr = ""; // initializes the input string to an empty string
            string errorMsg = ""; // initializes the error message to an empty string
            while (true)
            {
                Thread exit = new Thread(EndingLoop);
                exit.Start(); // starts the thread to check for the exit key each time the calculator is run
                Console.Clear(); //clears the console window to remove the previous graphic and output instances
                Display.CalculatorGraphic(errorMsg, inputStr);
                
                static void Calc(string errorMsg, string inputStr)
                {
                    Console.Clear(); //clears the console window to remove the previous graphic and any text/errors
                    Display.CalculatorGraphic(inputStr, errorMsg);
                }

                // The input prompt object returns either an integer if successful, or an error string if there's an error
                // Therefore, the object is returned as a tuple, so they are assigned from the Tuple<>.Item# Properties
                Equation userInput = new InputArea().Prompt();
                errorMsg = userInput._operations[0];
                inputStr = userInput._terms[0].ToString();
                //EpicKip. (2017, April 14). Answer to ‘Returning string and int from same method’. Stack Overflow. https://stackoverflow.com/a/43406662
                
                //Microsoft. (n.d.). Tuple<T1,T2>.Item1 Property (System). Retrieved 6 June 2024, from https://learn.microsoft.com/en-us/dotnet/api/system.tuple-2.item1?view=net-8.0
                
                // Calc(errorMsg, inputStr); //calls the calculator graphic method with the error message if there's an error
            }
        }
    }
}