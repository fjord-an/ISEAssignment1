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
        public int[] _terms;
        public List<string> _operations;
        
        public Equation(List<string> operations, string[] terms) // Constructor
        {
            this._operations = operations;
            this._terms = int.Parse(terms);
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