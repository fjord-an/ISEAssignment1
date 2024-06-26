namespace Calculator
{
    class Program
    {
        private static char q;
        internal static void EndingLoop() // Method checking for the exit key, executed in a separate thread called from Main()
        {
            while (q != 'q' || q != 'Q')
            {
                q = Console.ReadKey().KeyChar;
                if (q == 'q' || q == 'Q')
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
            string inputStr = "";   // initializes the input string to an empty string
            string errorMsg = "";   // initializes the error message to an empty string
            while (!inputStr.Contains('q') && !inputStr.Contains('Q')) // loop until user enters 'q' or 'Q' in the input
            {
                Console.Clear();    //clears the console window to remove the previous graphic and output instances
                Display.CalculatorGraphic(errorMsg, inputStr);
                // The input prompt object returns either an integer if successful, or an error string if there's an error
                // Therefore, the object is returned as a tuple, so they are assigned from the Tuple<>.Item# Properties
                
                Equation userInput = new InputArea().Prompt();
                errorMsg = userInput.Operations[^1];
                inputStr = userInput.Operations[0];
                

                //EpicKip. (2017, April 14). Answer to ‘Returning string and int from same method’. Stack Overflow. https://stackoverflow.com/a/43406662

                //Microsoft. (n.d.). Tuple<T1,T2>.Item1 Property (System). Retrieved 6 June 2024, from https://learn.microsoft.com/en-us/dotnet/api/system.tuple-2.item1?view=net-8.0

                // Calc(errorMsg, inputStr); //calls the calculator graphic method with the error message if there's an error
            }
            Console.Clear();
            Console.WriteLine("Q was entered: exiting calculator..."); // exit message
        }
    }
}