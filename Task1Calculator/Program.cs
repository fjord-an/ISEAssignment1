using System;
using Microsoft.VisualBasic.CompilerServices;

namespace Calculator
{
    class Program
    {
        private static void Main()
        {
            string inputStr = "0";
            string errorMsg = "";
            while (true)
            {
                if (inputStr == "0")
                {
                    Console.Clear();
                    Display.CalculatorGraphic(inputStr, errorMsg);
                }
                else if (inputStr == "x" || inputStr == "X") //if the user enters 'x' or 'X', the program will exit
                {
                    break; //cannot exit as the inputarea.cs catches any input thats not an integer
                }
                
                static void Calc(string errorMsg, string inputStr)
                {
                    Console.Clear(); //clears the console window to remove the previous graphic and any text/errors
                    Display.CalculatorGraphic(inputStr, errorMsg);
                }

                // The input prompt object returns either an integer if successful, or an error string if there's an error
                // Therefore, the object is returned as a tuple, so they are assigned from the Tuple<>.Item# Properties
                Tuple<int, string> userInput = InputArea.Prompt();
                errorMsg = userInput.Item2;
                //EpicKip. (2017, April 14). Answer to ‘Returning string and int from same method’. Stack Overflow. https://stackoverflow.com/a/43406662
                var inputInt = userInput.Item1;
                //Microsoft. (n.d.). Tuple<T1,T2>.Item1 Property (System). Retrieved 6 June 2024, from https://learn.microsoft.com/en-us/dotnet/api/system.tuple-2.item1?view=net-8.0
                inputStr = Convert.ToString(userInput.Item1);

                Calc(errorMsg, inputStr); //calls the calculator graphic method with the error message if there's an error
            }
        }
    }
}