//# Created by Jordan Pacey. Student ID: A00144357

using System.Security.Cryptography;
using System.Text;

namespace Task3Password;

internal class NewPassword
{   /*
     * This class is used to hash a new user's password and store it in the database.txt file.
     * it contains a single method which performs this operation and redirects the user to the login class
     *
     * This class has been adapted and supported by the tutorials provided by:
     * Code Maze. (2022, November 28). Hashing and Salting Passwords in C#—Best Practices. Code Maze.
     * https://code-maze.com/csharp-hashing-salting-passwords-best-practices/
    */
    public static void HashedPassword(string plainTextPassword, string userName)
    {
        string Hash(string password, out byte[] salt) 
            // output parameter salt is declared in the method signature
            // the plain text password is hashed and the salt is generated
        {
            salt = RandomNumberGenerator.GetBytes(HashParameters.KeySize);
            var hash = Rfc2898DeriveBytes.Pbkdf2(Encoding.UTF8.GetBytes(password), salt,
                HashParameters.Iterations, HashAlgorithmName.SHA512, HashParameters.KeySize);
            /* The Rfc2898DeriveBytes.Pbkdf2 method is used to hash the password with the salt. It takes 5 parameters:
                 1. The password to hash, 2. The salt to use, 3. The number of iterations to perform on the password,
                 4. The hash algorithm to use, 5. The key size of the hashed password. The Iterations and Keysize are
                 defined in the HashParameters.cs file for convenience and consistency throughout the namespace */
                
            return Convert.ToHexString(hash);
            // The hashed password is stored as a hexadecimal string to store in the file. It would be impossible to store
            // the hashed password as a byte array in the file. The hexadecimal string is converted back to a byte array
            // with the Convert.FromHexString when the hashed password needs to be compared to the user's input
        }

        var hash = Hash(plainTextPassword, out byte[] salt);
        //output parameter. the out keyword is used to pass a reference of the salt variable to the Hash method
        //BillWagner. (2024, March 30). out keyword—C# reference.
        //https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/out
        
        string hexSalt = Convert.ToHexString(salt); // The salt is also stored in the file as a hexadecimal string
        
        // StreamWriter object is encapsulated in the using statement so that the file stream closes after writing
        //Donut. (2011, March 1). Answer to “Closing a file after File.Create.” Stack Overflow. https://stackoverflow.com/a/5156300
        using (StreamWriter sw = new StreamWriter("database.txt", true))
            //Bråthen, Ø. (2011, September 5). Answer to “Append lines to a file using a StreamWriter.”
            //Stack Overflow. https://stackoverflow.com/a/7306236
        {
            sw.Write($"{userName}:{hash}:{hexSalt}{Environment.NewLine}");
            // The hashed password and salt are written to the file in the format "userName:hashedpassword:salt"
            // The Environment.NewLine is used to ensure that the next entry is written on a new line regardless of the OS
            // (\r\n for Windows, \n for Linux and MacOS)
        }
        
        // finally, the user is redirected to the login page and will log in with their new credentials automatically
        Verify.Login(userName, plainTextPassword, hash, salt);
    }
}