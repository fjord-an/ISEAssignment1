using System;

namespace MarkGrader
{
    internal static class Program
    {
        internal static void Main()
        {
            byte score = 0;
            //initialize score to 255 to test the invalid score condition
            Console.WriteLine("Enter your score: ");

            try
            {
                score = Convert.ToByte(Console.ReadLine());
                if (score > 100)
                {
                    throw new Exception("Error!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "\nPlease enter a valid score between 0 and 100");
                // if the score is invalid, the program will return to the beginning of the Main method
                Console.WriteLine("\nTrying again... (Press Ctrl + C to exit)");
                Main();
                return;
                // return to prevent the program from continuing to the next code block after the catch block
                // otherwise the program provided unexpected outputs
            }

            var output = "Your Grade is:\n" + Grades.Classifications(score);
            Console.WriteLine(output);
        }
    }
}
