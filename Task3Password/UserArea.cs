//# Created by Jordan Pacey. Student ID: A00144357

using System.Security.Cryptography;

namespace Task3Password;

public class UserArea
{
    internal static void UserPage(string userName)
    {
        // Console Colours: Byers, M. (2010, April 30). Answer to “Is it possible to write to the console in colour in .NET?”
        // Stack Overflow. https://stackoverflow.com/a/2743268
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\nAccess Granted, welcome {userName}!"); //The successful login message as required by the task
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Blue;
        // Pretending to be the user area with an imaginary secret stuff function:
        Console.WriteLine("This is the user area, This is your secret stuff:");
        secretStuff(userName);
    }

    private static void secretStuff(string userName)
    {
        // using the same approach as the UserInfo class to find the user in the database, 
        // i am printing the secret stuff of the user (which is the password hash and salt)
        using (StreamReader fs = new StreamReader("database.txt"))
        {
            int counter = 0;
            string line;

            while ((line = fs.ReadLine()) != null)
            {
                if (string.Equals(userName, line.Split(':')[0], StringComparison.OrdinalIgnoreCase)) 
                    // String comparison Overload StringComparison.OrdinalIgnoreCase is used to ignore case sensitivity
                {
                    string[] userDetails = line.Split(':');
                    Console.WriteLine($"Your SHA512 Hashed password:\n {userDetails[1]}");
                    Console.WriteLine($"Your salt:\n {userDetails[2]}");
                    Console.WriteLine();
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please exit the program then try Logging into your account again with the passwo" +
                                      "rd you created to test the encrypted password verifier feature with the" +
                                      " database.txt! \n(press any key to exit)");
                    Console.ReadKey();
                }
                else
                {
                    counter++;
                    continue;
                }
            }
        }
    }
}