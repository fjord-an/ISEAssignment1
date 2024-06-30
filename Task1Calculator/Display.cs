namespace Calculator;

static class Display
{
    /***
     * This method displays the calculator graphic on the console window
     * The graphic is a simple ASCII representation of a calculator
     *
     * The cursor is placed at the top left of the console window to replace the graphic with the updated values
     * every time the method is called, this gives the illusion of a dynamic calculator that changes values instead
     * of printing new calculators in the console window.
     *
     * The graphic is printed as lines, with each line of the calculator being a string in an array of strings
     * The caret (cursor) is placed at the first X in the graphic to show the value being entered. The cursor is
     * moved to the position of the X from line 2 (array index 2) of the graphic.
     */
    public static void CalculatorGraphic(string result, string inputStr, string errorMsg) // accepts any number of string inputs as arguments
    {
        Console.SetCursorPosition(0, 0); 
        //set cursor position to the top left of the console window to replace the graphic with the updated values!
        // this will draw the calculator graphic at the correct position each time the method is called
        Console.BackgroundColor = ConsoleColor.DarkBlue;
        Console.ForegroundColor = ConsoleColor.White;
        string calcGraphic =
                 """
                 +===========Calculator============+
                 |                                 |
                 |                                 |
                 +===+===+===+===+===+===+===+=====+
                 | / | * | - | + | ^ | % | Q | U/D |
                 +===+===+===+===+===+===+===+=====+
                 |Enter Q to Quit|=|Up/Down History|
                 ===================================
                  Type over previous input to edit  
                  Note: History in Powershell only  
                 """; 
        Console.ResetColor();
        //PLEASE NOTE: The input history feature only works in windows terminal (powershell)
        //Multiline Strings in C# | Mosh. (2015)
        
        string[] calcGraphicLines = calcGraphic.Split('\n');
        calcGraphicLines[1] = calcGraphicLines[1];
        calcGraphicLines[2] = calcGraphicLines[2];
        // int caretIndex = output[0].Length > 1 ? output[0].Length : 2;
        int caretIndex = 2;
        
        // ternary operator to check if there's an input, if there is, set the caret index to the length of the input
        // else set the cursor to number character 2 in the graphic

        
        // write output data to the calculator graphic array (error message, input values, calculations, etc.)
        calcGraphicLines[1] = calcGraphicLines[1].Substring(0, caretIndex) //calcGraphicLines[1] is the input line
                              + (inputStr != "" || inputStr != "0" ? inputStr : '?') //caretIndex is the position of the cursor
                              + calcGraphicLines[1].Substring(caretIndex,
                                  calcGraphicLines[1].Length - inputStr.Length - 4) + '|';
        // ^ ternary operation: If input is not 0 (default), replace caret index with input value, else replace with '?'. 
        string output = "";
        if (result != "" && result != "0")
            output = result;
        else if (errorMsg != "" && errorMsg != "0")
            output = errorMsg;
        
        calcGraphicLines[2] = calcGraphicLines[2].Substring(0, caretIndex) + output + 
                                          calcGraphicLines[2].Substring(caretIndex,
                                              calcGraphicLines[2].Length - output.Length - 4) + '|';
        // Concatenate remaining characters to maintain graphic structure. 
        // Calculate remaining string length considering input/output length, caret index and spacing.

        Console.ForegroundColor = ConsoleColor.Black;
        Console.BackgroundColor = ConsoleColor.DarkGreen;
        foreach (var line in calcGraphicLines) // then write each line of the calculator graphic
        {
            Console.WriteLine(line);
            //prints each line of the calculator graphic
            if (line == calcGraphicLines[1] && output != "")
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Black;
            }
        }

        Console.SetCursorPosition(caretIndex, 1);
        //sets the cursor position to the caret index (x), and the index of the input line (y) of the console window
        Console.ResetColor();
    }
}