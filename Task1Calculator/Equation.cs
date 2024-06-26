namespace Calculator
{
    internal class Equation
    { //fields: operands and operations
        internal List<double> Terms;
        internal List<string> Operations;
        
        internal Equation(List<string> output, List<double> operands) // Constructor
        {
            this.Operations = output;
            this.Terms = operands;
            Operations.Add(Calculate()); // Call the Calculate method to calculate the result of the equation
        }

        // int Calculate() // Method to calculate the result of the equation
        // {
        //     _operations.ForEach(Calculate); // Initialize the result with the first operand
        //     int result = _terms[1]; // Initialize the result with the first operand
        //     return result; // Return the final result
        // }

        private string Calculate()
        {
            double result;
            switch (Operations[1])
            {
                case "+":
                    result = Terms[0] + Terms[1];
                    return result.ToString();
                case "-":
                    result = Terms[0] - Terms[1];
                    return result.ToString();
                case "*":
                    result = Terms[0] * Terms[1];
                    return result.ToString();
                case "/":
                    result = Terms[0] / Terms[1];
                    return result.ToString();
                case "%":
                    result = Terms[0] % Terms[1];
                    return result.ToString();
                case "^":
                    result = Math.Pow(Terms[0], Terms[1]);
                    return result.ToString();
                default:
                    return "Cannot calculate";
            }
        }
    }
}