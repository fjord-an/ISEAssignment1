namespace Task3Password
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter a password: ");
            string plainTextPassword = Console.ReadLine();

            try
            {
                if (string.IsNullOrEmpty(plainTextPassword)) 
                // check if the password is null or empty (cleaner than checking for null and empty separately with ||)
                {
                    throw new ArgumentNullException(); 
                    //Argument null exception handles null or empty strings with a relavant message
                    //https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception?view=net-8.0
                }
                else if (plainTextPassword.Length is > 8 and < 24)
                {
                    Console.WriteLine("Password must be at least 8 characters long.");
                    throw new ArgumentException(nameof(plainTextPassword) + " must be between 8 to 24 characters long.");
                }
                else
                {
                    NewPassword.HashedPassword(plainTextPassword);
    
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"The password hashing failed. {e.Message}");
            }
            
        }
    }
}