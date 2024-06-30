using System.Globalization;

namespace Task3Password
{
    class Program
    {
            static void Main()
        {
            /*
             * This is the main method that will be used to run the password hashing program.
             * It contains a login prompt that will ask the user for a password and username.
             * It handles errors and the login flow. executing login related functions.
             */
            
            string[] userInfo = UserInfo.GetUserName("userName", "").Split(':');
            
            try
            {
                Console.WriteLine("Enter a Password:");
                string plainTextPassword = Console.ReadLine();
                
                string userName = userInfo[0];
                string hashedPassword;
                
                if (userName != "User not found" && userName != "User Error")
                {                
                    // check if the user exists in the database.txt file before proceeding
                    hashedPassword = userInfo[1];
                }
                else
                {
                    throw new ArgumentNullException(userName); 
                    //Argument null exception handles null or empty strings with a relavant message
                    //https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception?view=net-8.0
                }
                
                if (plainTextPassword.Length is < 8 or > 24)
                {
                    throw new ArgumentException(" must be between 8 to 24 characters long.");
                }
                else
                {
                    NewPassword.HashedPassword(plainTextPassword, userName);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"The password hashing failed. {e.Message}");
                // Main();
            }
            
        }
    }
}