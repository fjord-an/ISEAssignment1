using Microsoft.VisualBasic.CompilerServices;

namespace Calculator;

internal class InputArea
{
    public char[] operators = ['+', '-', '*', '/', '%', '^'];
    public List<int> operands = new List<int>();         // create a list to store the operands (or terms)
    public List<string> operations = new List<string>(); // create a list to store the operations (or operators)
    /***
     * This method prompts the user for an integer input
     * The method returns a tuple with both the integer input and an error message if there's an error
     * The error message is null if the input is successful
     */
    internal Equation Prompt()
    {
        /* Reference: C# Tutorial - Try Catch Block | Mosh. (2015)
        Exceptions | LinkedIn Learning. (2023). Retrieved 5 June 2024,
        from https://www.linkedin.com/learning/learning-c-sharp-8581491/exceptions?resume=false&u=56744473 */
        try 
        {
            string rawInput = Console.ReadLine();
            string[] terms = rawInput.Split(this.operators);
            
            foreach (string i in terms) // iterate through the terms and convert them to integers
            {// also check if the input is a valid integer, if not, throw an exception
                int result = int.TryParse(i, out int num)
                    ? num // if the parsing is successful, assign the result to the num variable with ternary operator
                    : throw new Exception("Invalid input"); // else throw an exception
                operands.Add(num);
            }
            
            foreach (char c in rawInput)
            {
                if (this.operators.Contains(c))
                {
                    this.operations.Add(c.ToString());
                }
            }
            
            if (this.operations.Count == 0)
            {
                throw new Exception("Invalid input");
            }
            
            if (this.operations.Count < this.operands.Count)
            {
                throw new Exception("Invalid input");
            }
            
            /*
             The input is parsed to an integer, if the parsing is successful, the result is assigned to the input variable
            If the parsing is unsuccessful, an exception is thrown with the message "Invalid input". This is done using
            the ternary operator to check if the parsing is successful, if it is, the statement will be true and return
            result variable to in the input variable, else it will throw an exception with the message "Invalid input"
            */

            return new Equation(operations, operands);

            // #### return new Tuple<int, string>(2, null); old return value 

            // If the input is successful, the method returns an Equation Class Object with the inputs and an empty
            // error message
        }
        catch (Exception e)
        {
            List<string> error = new List<string>();
            error.Add(e.Message);
            List<int> output = new List<int>(); // if there's an error, the output is set to 0 to return a value
            output.Add(0);                      // this stops the referencing of a null object error
            return new Equation(error, output);
            // error message is passed with the exception message, and the input is null.
            // that way the error message is displayed in the calculator graphic instead of the input
        }
    }
}