using System.Security.Cryptography;
using System.Text;

namespace Task3Password;

internal class NewPassword
{
    public static void HashedPassword(string plainTextPassword, string userName)
    {
        HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512; 
        // The hash algorithm I am using to hash the password. It needs to be instantiated to use the Pbkdf2 method
        // The method needs to use a struct field of the HashAlgorithmName type to hash the password with the salt
            
        string Hash(string password, out byte[] salt) 
            // output parameter salt is declared in the method signature
            // the plain text password is hashed and the salt is generated
        {
            salt = RandomNumberGenerator.GetBytes(HashParameters.KeySize);
            var hash = Rfc2898DeriveBytes.Pbkdf2(Encoding.UTF8.GetBytes(password), salt,
                HashParameters.Iterations, hashAlgorithm, HashParameters.KeySize);
            /* The Rfc2898DeriveBytes.Pbkdf2 method is used to hash the password with the salt. It takes 5 parameters:
                 1. The password to hash, 2. The salt to use, 3. The number of iterations to perform on the password,
                 4. The hash algorithm to use, 5. The key size of the hashed password. The Iterations and Keysize are
                 defined in the HashParameters.cs file for convenience and consistency throughout the namespace */
                
            return Convert.ToHexString(hash);
            // The hashed password is stored as a hexadecimal string to store in the file
        }

        var hash = Hash(plainTextPassword, out byte[] salt);
        string hexSalt = Convert.ToHexString(salt); //### REFERENCE????
        //output parameter. the out keyword is used to pass a reference
        
        Console.WriteLine($"Password hash: {hash}");
        Console.WriteLine($"Generated salt: {hexSalt}");
        
        using (StreamWriter sw = new StreamWriter("database.txt", true))
        {// The StreamWriter object is encapsulated in the using statement so that the stream closes after writing
            // the append overload was used to ensure that the file is not overwritten (true)
            sw.Write($"{userName}:{hash}:{hexSalt}{Environment.NewLine}");
            // The hashed password and salt are written to the file in the format "userName:hashedpassword:salt"
            // The Environment.NewLine is used to ensure that the next entry is written on a new line regardless of the OS
            // (\r\n for Windows, \n for Linux and MacOS)
        }//#####################SOURCE USING????
        
        //###MOSH Need to check wether this is the correct way to store the password
        // and can it be compared in verify?
            
        Verify.Login(userName, plainTextPassword, hash, salt, hashAlgorithm);
    }
}