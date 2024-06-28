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
    public static void CalculatorGraphic(params string[] output) // accepts any number of string inputs as arguments
    {
        Console.SetCursorPosition(0, 0); 
        //set cursor position to the top left of the console window to replace the graphic with the updated values!
        // this will draw the calculator graphic at the correct position each time the method is called
        
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
                 
                  Note: History in Powershell only
                 """; 
        //PLEASE NOTE: The input history feature only works in windows terminal (powershell)
        //Multiline Strings in C# | Mosh. (2015)
        
        string inputStr = output[1];
        string errorMsg = output[0];
        
        string[] calcGraphicLines = calcGraphic.Split('\n');
        string inputLine = calcGraphicLines[1];
        string outputLine = calcGraphicLines[2];
        // int caretIndex = output[0].Length > 1 ? output[0].Length : 2;
        int caretIndex = 2;
        
        // ternary operator to check if there's an input, if there is, set the caret index to the length of the input
        // else set the cursor to number character 2 in the graphic
        
        // write output data to the calculator graphic array (error message, input values, calculations, etc.)
        calcGraphicLines[1] = inputLine.Substring(0, caretIndex) //calcGraphicLines[1] is the input line
                              + (inputStr != "" || inputStr != "0" ? inputStr : '?') //caretIndex is the position of the cursor
                              + inputLine.Substring(caretIndex,
                                  inputLine.Length - inputStr.Length - 3) + '|';
        // ^ ternary operation: If input is not 0 (default), replace caret index with input value, else replace with '?'. 
        if (errorMsg != "")
            calcGraphicLines[2] = outputLine.Substring(0, caretIndex) + errorMsg + 
                                          outputLine.Substring(errorMsg.Length,
                                              outputLine.Length - errorMsg.Length - 4) + '|';
        // Concatenate remaining characters to maintain graphic structure. 
        // Calculate remaining string length considering input/output length, caret index and spacing.
        
        

        foreach (var line in calcGraphicLines) // then write each line of the calculator graphic
        {
            Console.WriteLine(line);
            //prints each line of the calculator graphic
        }

        Console.SetCursorPosition(caretIndex, 1);
        //sets the cursor position to the caret index (x), and the index of the input line (y) of the console window
    }
}