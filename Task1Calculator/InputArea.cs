using Microsoft.VisualBasic.CompilerServices;

namespace Calculator;

public class InputArea
{
    public char[] operators = ['+', '-', '*', '/', '%', '^'];
    public char[] operands = ['0', '1', '2', '3', '4', '5', '6', '7', '8', '9'];
    public List<string> operations = new List<string>();
    /***
     * This method prompts the user for an integer input
     * The method returns a tuple with both the integer input and an error message if there's an error
     * The error message is null if the input is successful
     */
    public Equation Prompt()
    {
        // Reference: C# Tutorial - Try Catch Block | Mosh. (2015)
        try //Exceptions | LinkedIn Learning. (2023). Retrieved 5 June 2024, from https://www.linkedin.com/learning/learning-c-sharp-8581491/exceptions?resume=false&u=56744473
        {
            string rawInput = Console.ReadLine();
            string[] terms = rawInput.Split(this.operators);
            
            foreach (string i in terms) // iterate through the terms and convert them to integers
            {// also check if the input is a valid integer, if not, throw an exception
                int result = int.TryParse(i, out int operand)
                    ? operand
                    : throw new Exception("Invalid input");
            }
            
            foreach (char c in rawInput)
            {
                if (this.operators.Contains(c))
                {
                    operations.Add(c.ToString());
                }
            }
            //### int input = int.TryParse(operands, out int result) ? result : throw new Exception("Invalid input");
            
            // The input is parsed to an integer, if the parsing is successful, the result is assigned to the input variable
            // If the parsing is unsuccessful, an exception is thrown with the message "Invalid input". This is done using
            // the ternary operator to check if the parsing is successful, if it is, the statement will be true and return
            // result variable to in the input variable, else it will throw an exception with the message "Invalid input"

            return new Equation(operations, terms);

            // #### return new Tuple<int, string>(2, null); old return value 

            // If the input is successful, the method returns a tuple with the input and a null error message
        }
        catch (Exception e)
        {
            return new Equation(null, e.Message);
            // If there's an exception, the method returns a tuple with empty input and the exception message to display
        }
    }
}