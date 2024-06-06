using System;
using Microsoft.VisualBasic.CompilerServices;

namespace ISEAssignment1
{
    class Program
    {
        private static void Main()
        {
            void Calc(string errorMsg)
            {
                CalculatorGraphic();
                if (errorMsg != null)
                {
                    Console.WriteLine(errorMsg);
                }
                Console.Clear(); //clears the console window to remove the previous graphic and any text/errors
            }

            CalculatorGraphic();
            var errorMsg = Prompt().Item2; //EpicKip. (2017, April 14). Answer to ‘Returning string and int from same method’. Stack Overflow. https://stackoverflow.com/a/43406662
            //microsoft. (n.d.). Tuple<T1,T2>.Item2 Property (System). Retrieved 6 June 2024, from https://learn.microsoft.com/en-us/dotnet/api/system.tuple-2.item2?view=net-8.0
            Calc(errorMsg); //calls the calculator graphic method with no error message

            Console.WriteLine("\n\n asdf");
            
            Main();
        }

        private static void CalculatorGraphic()
        {
            Console.SetCursorPosition(0, 0); //set cursor position to the top left of the console window to replace the graphic with the updated values!

            string calcGraphic =
                """

                +==========Calculator=========+
                |       X      ?      X       |
                +=====+=====+=====+=====+=====+
                |  7  |  8  |  9  |  /  |  C  |
                |  4  |  5  |  6  |  *  |  ^  |
                |  1  |  2  |  3  |  -  |  +  |
                +-----+-----+-----+-----+-----+
                """;                                            //Multiline Strings in C# | Mosh. (2015)
            
            string[] calcGraphicLines = calcGraphic.Split('\n');
            var caretIndex = calcGraphicLines[2].IndexOf("X"); //retrieves the index of the first X in the graphic to place the caret
            
            for (int i = 0; i < caretIndex; i++)
            {
                //append a space to the caret index string to move it to the right
                calcGraphicLines[2] = calcGraphicLines[2].Substring(0, caretIndex) + " " + calcGraphicLines[2].Substring(caretIndex + 1);
            }
            foreach (var line in calcGraphicLines)
            {
                Console.WriteLine(line);
            }
            
            Console.SetCursorPosition(caretIndex, 2); //sets the cursor position to the caret index to show the value being entered
        }
        
        private static Tuple<int, string> Prompt()
        {
            // Reference: C# Tutorial - Try Catch Block | Mosh. (2015)
            try //Exceptions | LinkedIn Learning. (2023). Retrieved 5 June 2024, from https://www.linkedin.com/learning/learning-c-sharp-8581491/exceptions?resume=false&u=56744473
            {
                var input = int.Parse(Console.ReadLine());
                return new Tuple<int, string>(input, null);
            }
            catch (Exception e)
            {
                return new Tuple<int, string>(0 ,e.Message);
            }
        }
    }
}