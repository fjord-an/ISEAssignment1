using System.Globalization;

namespace Task3Password
{
    class Program
    {
            static void Main()
        {
            // string userName = GetUserName();
            //
            // if (userName == "User Error")
            // {
            //     Console.WriteLine("An error occurred while creating the user account.");
            //     return;
            // }
            string[] userInfo = UserInfo.GetUserName("userName", "").Split(':');
            
            try
            {
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
                
                FileStream fs = new FileStream("database.txt", FileMode.Open, FileAccess.ReadWrite);
                
                if (hashedPassword.Length is < 8 or > 24)
                {
                    throw new ArgumentException(" must be between 8 to 24 characters long.");
                }
                else
                {
                    NewPassword.HashedPassword(hashedPassword, userName);
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