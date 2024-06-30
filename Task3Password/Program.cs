namespace Task3Password
{
    class Program
    {
        /*
         * The main class of the password hashing program.
         */
            static void Main()
        {
            /*
             * This is the main method that will be used to run the password hashing program.
             * It contains a login prompt that will ask the user for a password and username.
             * It handles errors and the login flow. executing login related functions.
             * Further commentaries are provided in the other class files
             */
            
            string[] userInfo = UserInfo.GetUserName("userName", "").Split(':');
            // The GetUserName method is used to get the username and hashed password from the database.txt file
            // it returns a string in the format "userName:hashedpassword:salt" which is split into an array to access
            // the individual elements
            
            try // The try block is used to catch any exceptions that may be thrown by the code block
            {
                // Initialising the variables used in the method:
                string newUserName;
                string userName = userInfo[0];
                string plainTextPassword;
                string hashedPassword;
                byte[] salt;
                
                if (userName != "User not found" && userName != "User Error") // if the user is found in the database:
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
                    
                    if (newUserName == "") // check if the username is empty
                    {
                        throw new ArgumentNullException("Username cannot be empty.");
                    }
                    else if (newUserName.Length > 16 && newUserName.Length < 5) // check if the username is between 4 and 16 characters
                    {
                        throw new ArgumentException("Username must be between 4 and 16 characters long.");
                    }
                    
                    Console.WriteLine("Please enter password\n(Password must alphanumeric be between 8 and 24 characters " +
                                      "long. It must contain alphanumeric characters, with at least 1 digit, number and " +
                                      "special character)");
                    
                    string passwordBuffer = Console.ReadLine(); // The password is stored in a buffer to check the requirements
                    string confirmPassword;                     // The user is asked to confirm the password to avoid typos
                    char[] plainTextCharacters = passwordBuffer.ToCharArray(); 
                    // The password is converted to a char array to check if the characters meet the requirements
                    // These useful, built-in methods avoid the need to use a for loop to iterate through the characters
                    // of the string to check if they meet the requirements:

                    
                    if (plainTextCharacters.Any(char.IsDigit) && plainTextCharacters.Any(char.IsLetter) && 
                        plainTextCharacters.Any(char.IsUpper) && plainTextCharacters.Any(char.IsLower) &&
                        (plainTextCharacters.Any(char.IsSymbol) || plainTextCharacters.Any(char.IsPunctuation)))
                    { // The password must contain at least 1 digit, number, special character, uppercase and lowercase letter to be true
                        
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
                        
                        // The password is hashed and stored in the database.txt file using the NewPassword class
                        plainTextPassword = passwordBuffer.ToString();
                        NewPassword.HashedPassword(plainTextPassword, newUserName);
                    }
                    else
                    {
                        throw new ArgumentException("Password must contain at least 1 digit, number, special character, " +
                                                    "uppercase and lowercase letter.");
                    }

                    // throw new ArgumentNullException(userName); 
                    //Argument null exception handles null or empty strings with a relavant message
                    //https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception?view=net-8.0
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"User creation failed. {e.Message}\nReturning to main menu...");
                Main();
            }
        }
    }
}