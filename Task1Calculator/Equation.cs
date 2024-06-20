using System.Reflection.Metadata;
using System.Runtime.InteropServices.JavaScript;

namespace Calculator
{
    // public enum Operations
    // {
    //     Add = '+',
    //     Subtract = '-',
    //     Multiply = '*',
    //     Divide = '/',
    //     Modulus = '%',
    //     Power = '^',
    //     Invalid = ' '
    // }
    public class Equation
    { //fields: operands and operations
        public int[] _operands;
        public char[] _operations;
        public char[] _operators;
        
        public Equation(string[] rawInput) // Constructor
        {
            this._operands = rawInput[0]
            this._operators = ['+', '-', '*', '/', '%', '^'];
            rawInput.Select(int.Parse).ToArray();
    
            _operations = (rawInput);
        }
        
        public static string[] Operands(string rawInput)
        {
            string[] operands = rawInput.Split(operators);
            return operands;
        }

        int Calculate() // Method to calculate the result of the equation
        {
            
            int result = _operands[0]; // Initialize the result with the first operand
            for (int i = 1; i < _operands.Length; i++) // Loop through the remaining operands
            {
                switch (_operations) // Switch statement to perform the operation based on the operator
                {
                    case Operations.Add:
                        result += _operands[i];
                        break;
                    case Operations.Subtract:
                        result -= _operands[i];
                        break;
                    case Operations.Multiply:
                        result *= _operands[i];
                        break;
                    case Operations.Divide:
                        result /= _operands[i];
                        break;
                    case Operations.Modulus:
                        result %= _operands[i];
                        break;
                    case Operations.Power:
                        result = (int)Math.Pow(result, _operands[i]);
                        break;
                    default:
                        throw new InvalidOperationException("Invalid operation");
                }
            }
            return result; // Return the final result
        }
    }   
}