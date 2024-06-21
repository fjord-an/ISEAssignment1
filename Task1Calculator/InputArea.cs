using Microsoft.VisualBasic.CompilerServices;

namespace Calculator;

public class InputArea
{
    public char[] operators = ['+', '-', '*', '/', '%', '^'];

    public char[] operands = ['0', '1', '2', '3', '4', '5', '6', '7', '8', '9'];
    /***
     * This method prompts the user for an integer input
     * The method returns a tuple with both the integer input and an error message if there's an error
     * The error message is null if the input is successful
     */
    public Tuple<int, string> Prompt()
    {
        // Reference: C# Tutorial - Try Catch Block | Mosh. (2015)
        try //Exceptions | LinkedIn Learning. (2023). Retrieved 5 June 2024, from https://www.linkedin.com/learning/learning-c-sharp-8581491/exceptions?resume=false&u=56744473
        {
            string rawInput = Console.ReadLine();
            string[] terms = rawInput.Split(this.operators);
            List<string> operators = new List<string>();
            foreach (char c in rawInput)
            {
                if (this.operators.Contains(c))
                {
                    operators.Add(c.ToString());
                }
            }
            //## int input = int.TryParse(operands, out int result) ? result : throw new Exception("Invalid input");
            
            // The input is parsed to an integer, if the parsing is successful, the result is assigned to the input variable
            // If the parsing is unsuccessful, an exception is thrown with the message "Invalid input". This is done using
            // the ternary operator to check if the parsing is successful, if it is, the statement will be true and return
            // result variable to in the input variable, else it will throw an exception with the message "Invalid input"
            
            return new Tuple<int, string>(2, null);
            
            // If the input is successful, the method returns a tuple with the input and a null error message
        }
        catch (Exception e)
        {
            return new Tuple<int, string>(0, e.Message);
            // If there's an exception, the method returns a tuple with empty input and the exception message to display
        }
    }
}