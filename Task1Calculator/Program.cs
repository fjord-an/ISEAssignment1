using System;
using Microsoft.VisualBasic.CompilerServices;

namespace ISEAssignment1
{
    class Program
    {
        private static void Main()
        {
            void Calc(string errorMsg)
            {
                Display.CalculatorGraphic();
                if (errorMsg != null)
                {
                    Console.WriteLine(errorMsg);
                }

                Console.Clear(); //clears the console window to remove the previous graphic and any text/errors
                Display.CalculatorGraphic();
            }

            Display.CalculatorGraphic();
            
            var
                errorMsg = InputArea.Prompt()
                    .Item2; //EpicKip. (2017, April 14). Answer to ‘Returning string and int from same method’. Stack Overflow. https://stackoverflow.com/a/43406662
            var
                input = InputArea.Prompt()
                    .Item1; //Microsoft. (n.d.). Tuple<T1,T2>.Item1 Property (System). Retrieved 6 June 2024, from https://learn.microsoft.com/en-us/dotnet/api/system.tuple-2.item1?view=net-8.0

            Calc(errorMsg); //calls the calculator graphic method with no error message

            Console.WriteLine("\n\n asdf");

            Main();
        }
    }
}