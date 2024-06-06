namespace ISEAssignment1;

static class Display
{
    public static void CalculatorGraphic()
    {
        Console.SetCursorPosition(0,
            0); //set cursor position to the top left of the console window to replace the graphic with the updated values!

        string calcGraphic =
            """

            +==========Calculator=========+
            | .                           |
            | X                           |
            +=====+=====+=====+=====+=====+
            | /  |  * | - | + | ^ | % | C |
            +====+====+===+===+===+===+===+
            """; //Multiline Strings in C# | Mosh. (2015)

        string[] calcGraphicLines = calcGraphic.Split('\n');
        var caretIndex = calcGraphicLines[3].IndexOf("X");
        //retrieves the index of the first X in the graphic to place the caret

        for (int i = 0; i < caretIndex; i++)
        {
            //append a space to the caret index string to move it to the right
            calcGraphicLines[3] = calcGraphicLines[3].Substring(0, caretIndex) + "?" +
                                  calcGraphicLines[3].Substring(caretIndex + 1);
        }

        foreach (var line in calcGraphicLines)
        {
            Console.WriteLine(line);
        }

        Console.SetCursorPosition(caretIndex,
            0); //sets the cursor position to the caret index to show the value being entered
    }
}