using System.Security.Cryptography;

namespace Task3Password;

public class UserArea
{
    internal static void UserPage(string userName)
    {
        Console.WriteLine($"Access Granted, welcome {userName}!");
        Console.WriteLine("This is the user area, This is your stuff");
    }
}