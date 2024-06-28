using System;
using System.Security.Cryptography;

namespace Task3Password
{
    class Program
    {
        static void Main()
        {
            Encrypt();
        }
        static void Encrypt()
        {
            try
            {
                using (FileStream fileStream = new("TestData.txt", FileMode.OpenOrCreate))
                {
                    using (Aes aes = Aes.Create())
                    {
                        byte[] key =
                        {
                            0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08,
                            0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16
                        };
                        aes.Key = key;

                        byte[] iv = aes.IV;
                        fileStream.Write(iv, 0, iv.Length);

                        using (CryptoStream cryptoStream = new(
                                   fileStream,
                                   aes.CreateEncryptor(),
                                   CryptoStreamMode.Write))
                        {
                            // By default, the StreamWriter uses UTF-8 encoding.
                            // To change the text encoding, pass the desired encoding as the second parameter.
                            // For example, new StreamWriter(cryptoStream, Encoding.Unicode).
                            using (StreamWriter encryptWriter = new(cryptoStream))
                            {
                                encryptWriter.WriteLine("Hello World!");
                            }
                        }
                    }
                }

                Console.WriteLine("The file was encrypted.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"The encryption failed. {ex}");
            }
        }
    
        //### NOTE! the .Any method can be used to check if a string contains a digit, letter, or special character
        static void Example()
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
        static void Example2()
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