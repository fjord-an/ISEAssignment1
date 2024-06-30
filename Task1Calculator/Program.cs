namespace Calculator
{
    class Program
    {
        internal static void Main()
        {
            string inputStr = "";   // initializes the input string to an empty string
            string result = "";     // initializes the result string to an empty string
            string errorMsg = "";   // initializes the error message to an empty string
            List<string> inputOutput = new List<string>(); 
            // creates a list to store the input, output, and error message
            
            while (!inputStr.Contains('q') && !inputStr.Contains('Q')) // loop until user enters 'q' or 'Q' in the input
            {
                Console.Clear();    //clears the console window to remove the previous graphic and output instances
                Display.CalculatorGraphic(result, inputStr, errorMsg);
                // The input prompt object returns either an integer if successful, or an error string if there's an error
                // Therefore, the object is returned as a tuple, so they are assigned from the Tuple<>.Item# Properties
                
                Equation userInput = new InputArea().Prompt();
                result = userInput.Result.ToString();
                inputStr = userInput.Operations[0];
                errorMsg = userInput.Operations[1];
                //EpicKip. (2017, April 14). Answer to ‘Returning string and int from same method’. Stack Overflow. https://stackoverflow.com/a/43406662
                //Microsoft. (n.d.). Tuple<T1,T2>.Item1 Property (System). Retrieved 6 June 2024, from https://learn.microsoft.com/en-us/dotnet/api/system.tuple-2.item1?view=net-8.0
                // ### Add mosh constructors class inheritance etc to these sources for above code
                // Calc(errorMsg, inputStr); //calls the calculator graphic method with the error message if there's an error
            }
            Console.Clear(); // execute when the user enters 'q' or 'Q', breaking the while loop above
            Console.WriteLine("Q was entered: exiting calculator..."); // exit message
        }
    }
}