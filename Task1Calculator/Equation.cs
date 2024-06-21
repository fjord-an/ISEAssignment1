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
            this._operators = ['+', '-', '*', '/', '%', '^'];
            rawInput.Select(int.Parse).ToArray();
        }

        int Calculate() // Method to calculate the result of the equation
        {
            
            int result = _operands[0]; // Initialize the result with the first operand
            for (int i = 1; i < _operands.Length; i++) // Loop through the remaining operands
            {
            }
            return result; // Return the final result
        }
    }   
}