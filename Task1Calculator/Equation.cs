using System.Reflection.Metadata;
using System.Runtime.InteropServices.JavaScript;

namespace Calculator
{
    internal class Equation
    { //fields: operands and operations
        public List<int> _terms;
        public List<string> _operations;
        
        internal Equation(List<string> output, List<int> operands) // Constructor
        {
            this._operations = output;
            this._terms = operands;
        }

        int Calculate() // Method to calculate the result of the equation
        {
            
            _operations.ForEach(Calculate); // Initialize the result with the first operand
            int result = _terms[1]; // Initialize the result with the first operand
            return result; // Return the final result
        }

        private void Calculate(string _operations)
        {
            switch (_operations)
            {
                case "+":
                    _terms[1] = _terms[0] + _terms[1];
                    break;
                case "-":
                    _terms[1] = _terms[0] - _terms[1];
                    break;
                case "*":
                    _terms[1] = _terms[0] * _terms[1];
                    break;
                case "/":
                    _terms[1] = _terms[0] / _terms[1];
                    break;
                case "%":
                    _terms[1] = _terms[0] % _terms[1];
                    break;
                case "^":
                    _terms[1] = _terms[0] ^ _terms[1];
                    break;
                default:
                    this._operations.Add("Invalid operation");
                    break;
            }
        }
    }   
}