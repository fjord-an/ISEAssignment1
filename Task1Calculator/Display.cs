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
    public static void CalculatorGraphic(params string[] input)
    {
        var inputStr = string.Join("", input);
        Console.SetCursorPosition(0,
            0); //set cursor position to the top left of the console window to replace the graphic with the updated values!

        string calcGraphic =
            """
            +==========Calculator=========+
            |                             |
            |                             |
            +=====+=====+=====+=====+=====+
            | /  |  * | - | + | ^ | % | C |
            +====+====+===+===+===+===+===+
            """; //Multiline Strings in C# | Mosh. (2015)

        string[] calcGraphicLines = calcGraphic.Split('\n');
        var caretIndex = input.Length > 1 ? input.Length : 2;
        // ternary operator to check if there's an input, if there is, set the caret index to the length of the input
        // else set the cursor to number character 2 in the graphic

        for (int i = 0; i < caretIndex; i++)
        {
            //append a space to the caret index string to move it to the right
            calcGraphicLines[1] = calcGraphicLines[1].Substring(0, caretIndex) + (inputStr != "0" ? inputStr : '?') +
                                  calcGraphicLines[1].Substring(caretIndex + 1);
        }

        foreach (var line in calcGraphicLines)
        {
            Console.WriteLine(line);
        }

        Console.SetCursorPosition(caretIndex, 1);
        //sets the cursor position to the caret index to show the value being entered
    }
}