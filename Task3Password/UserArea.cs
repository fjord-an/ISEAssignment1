using System.Security.Cryptography;

namespace Task3Password;

public class UserArea
{
    internal static void UserPage(string userName)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\nAccess Granted, welcome {userName}!");
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
            int counter = 0;        // counter is used to keep track of the line number
            string line;            // line is used to store the current line being read from the file

            while ((line = fs.ReadLine()) != null)
                // ensures the line is correct, and not at the end of the file. In which case it would be null.
            {
                if (string.Equals(userName, line.Split(':')[0], StringComparison.OrdinalIgnoreCase)) 
                {
                    string[] userDetails = line.Split(':');
                    Console.WriteLine($"Your SHA512 Hashed password:\n {userDetails[1]}");
                    Console.WriteLine($"Your salt:\n {userDetails[2]}");
                    Console.ResetColor();
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