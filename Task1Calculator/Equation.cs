//# Created by Jordan Pacey. Student ID: A00144357

namespace Calculator
{
    internal class Equation
    { //fields: operands and operations
        internal List<double> Terms;
        internal List<string> Operations;
        internal double Result;
        
        internal Equation(List<string> output, List<double> operands) // Constructor
        {// the constructor takes in two arguments, a list of strings and a list of doubles
            // the fields can be accessed by the properties of the class in the main() program
            this.Operations = output;
            this.Terms = operands;
            for(int i = 0; i < Operations.Count - 1; i++)
                this.Result = Calculate(i);
            // Call the Calculate method to calculate the result of the equation
        }
        
        private double Calculate(int i)
        {
            double result;
            
            switch (Operations[i+1])
            {
                case "+":
                    result = (Result <= 0 ? Terms[i] : Result) + Terms[i + 1];
                    return result;
                case "-":
                    result = (Result <= 0 ? Terms[i] : Result) - Terms[i + 1];
                    return result;
                case "*":
                    result = (Result <= 0 ? Terms[i] : Result) * Terms[i + 1];
                    return result;
                case "/":
                    result = (Result <= 0 ? Terms[i] : Result) / Terms[i + 1];
                    return result;
                case "%":
                    result = (Result <= 0 ? Terms[i] : Result) % Terms[i + 1];
                    return result;
                case "^":
                    result = Math.Pow((Result <= 0 ? Terms[i] : Result), Terms[i + 1]);
                    return result;
                default:
                    return 0;
            }
        }
    }
}