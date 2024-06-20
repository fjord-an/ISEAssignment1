using System.Net.Sockets;

namespace Calculator;

public class Operators
{
    public char[] types = ['+', '-', '*', '/', '%', '^'];
    public List<string> equation = new List<string>(rawInput);
    
    public int GetOperation(string op)
    {
        switch (op)
        {
            case "+":
                return ;
            case "-":
                return Operations.Subtract;
            case "*":
                return Operations.Multiply;
            case "/":
                return Operations.Divide;
            case "%":
                return Operations.Modulus;
            case "^":
                return Operations.Power;
            default:
                return Operations.Invalid;
        }
    }
}