using System;

namespace Password
{
    class Program
    {
        //### NOTE! the .Any method can be used to check if a string contains a digit, letter, or special character
        static void Main()
        {
            Console.WriteLine("Enter a password: ");
            string password = Console.ReadLine();

            if (password.Length < 8)
            {
                Console.WriteLine("Password must be at least 8 characters long.");
            }
            else
            {
                bool hasDigit = false;
                bool hasLetter = false;
                bool hasSpecialChar = false;

                foreach (char i in password)
                {
                    if (char.IsDigit(i))
                    {
                        hasDigit = true;
                    }
                    else if (char.IsLetter(i))
                    {
                        hasLetter = true;
                    }
                    else
                    {
                        hasSpecialChar = true;
                    }
                }

                if (hasDigit && hasLetter && hasSpecialChar)
                {
                    Console.WriteLine("Password is valid.");
                }
                else
                {
                    Console.WriteLine(
                        "Password must contain at least one digit, one letter, and one special character.");
                }
            }
        }
        // Example method (maybe incorrect for the quesiton, does not store the password in a variable and read it)
        static void Example()
        {
            do
            {
                bool hasDigit = false;
                bool hasLetter = false;
                bool hasSpecialChar = false;


                string user_input;
                Console.WriteLine(
                    "Please enter password, password should include a mix of digits, number and one special character");
                user_input = Convert.ToString(Console.ReadLine());
                foreach (char i in user_input)
                    if (char.IsDigit(i))
                    {
                        hasDigit = true;
                    }
                    else if (char.IsLetter(i))
                    {
                        hasLetter = true;
                    }
                    else
                    {
                        hasSpecialChar = true;
                    }

                if (hasDigit && hasLetter && hasSpecialChar)
                {
                    Console.WriteLine("Access granted. Welcome user!");
                    Console.WriteLine("Goodbye");
                    Console.ReadLine();
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect password, please try again.");
                }
            } while (true);
        }
    }
}