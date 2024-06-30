using System.Globalization;
using System.Security.Cryptography;

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
                string newUserName;
                string userName = userInfo[0];
                string plainTextPassword = "";
                string hashedPassword;
                byte[] salt;
                
                if (userName != "User not found" && userName != "User Error")
                {
                    // This code block is used to log in the user if the user is found in the database
                    Console.WriteLine("Enter your password:");
                    plainTextPassword = Console.ReadLine();
                    
                    // check if the user exists in the database.txt file before proceeding
                    hashedPassword = userInfo[1];
                    salt = Convert.FromHexString(userInfo[2]);
                    // The hashed password and salt are stored in the database.txt file in the format "userName:hashedpassword:salt"
                    // the salt Hexadecimal string is converted back to a byte array for use in the hashing function:
                    Verify.Login(userName, plainTextPassword, hashedPassword, salt);
                }
                else
                {
                    // This code block creates a new user if the user is not found in the database
                    Console.WriteLine("User not found... Please enter a new username to sign up:");
                    newUserName = Console.ReadLine();
                    
                    if (newUserName == "")
                    {
                        throw new ArgumentNullException("Username cannot be empty.");
                    }
                    else if (newUserName.Length > 16 && newUserName.Length < 5)
                    {
                        throw new ArgumentException("Username must be between 4 and 16 characters long.");
                    }
                    
                    Console.WriteLine("Please enter password (Password must alphanumeric be between 8 and 24 characters" +
                                      "long. It must contain alphanumeric characters, with at least 1 digit, number and " +
                                      "special character)\n");
                    
                    string passwordBuffer = Console.ReadLine();
                    string confirmPassword;
                    char[] plainTextCharacters = passwordBuffer.ToCharArray();
                    
                    if (plainTextCharacters.Any(char.IsDigit) && plainTextCharacters.Any(char.IsLetter) && 
                        plainTextCharacters.Any(char.IsUpper) && plainTextCharacters.Any(char.IsLower) &&
                        (plainTextCharacters.Any(char.IsSymbol) || plainTextCharacters.Any(char.IsPunctuation)))
                    {
                        if (passwordBuffer.Length is < 8 or > 24)
                        { // performing a seperate check to throw a different error message which is more helpful to the user
                            throw new ArgumentException(" must be between 8 to 24 characters long.");
                        }
                        
                        Console.WriteLine("Please re-enter password to confirm:");
                        confirmPassword = Console.ReadLine();
                        
                        if (passwordBuffer != confirmPassword)
                        {
                            throw new ArgumentException("Passwords do not match. Please try again.");
                        }
                        
                        plainTextPassword = passwordBuffer.ToString();
                        NewPassword.HashedPassword(plainTextPassword, newUserName);
                    }
                    else
                    {
                        throw new ArgumentException("Password must contain at least 1 digit, number, special character, " +
                                                    "uppercase and lowercase letter.");
                    }
                    // These useful, built-in methods avoid the need to use a for loop to iterate through the characters of the string
                    

                    // throw new ArgumentNullException(userName); 
                    //Argument null exception handles null or empty strings with a relavant message
                    //https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception?view=net-8.0
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"The password hashing failed. {e.Message}");
                Main();
            }
        }
    }
}