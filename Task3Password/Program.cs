using System.Security.Cryptography;
using System.Text;

namespace Task3Password
{
    public class Verify
    {
        // Verify the password
        public bool VerifyPassword(string password, string hash, byte[] salt, HashAlgorithmName hashAlgorithm)
        {
                
            // Hash the password and salt using the same key derivation function to compare the hashes
            var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(password, salt, HashParameters.Iterations, hashAlgorithm,
                HashParameters.KeySize);
                
            //return the result of the comparison of the two hashes using the CryptographicOperations.FixedTimeEquals method
            //??? Create a fixed-time comparison to prevent timing attacks???
            return CryptographicOperations.FixedTimeEquals(hashToCompare, Convert.FromHexString(hash));
        }// The CryptographicOperations.FixedTimeEquals method is used to compare the hash to prevent timing attacks
        // This is good practice for password hashing to prevent attackers from guessing the password based on the
        // time it takes to compare the hashes
    }

    internal class NewPassword
    {
        public static void HashedPassword(string plainTextPassword)
        {
            HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512; 
            // The hash algorithm I am using to hash the password. It needs to be instantiated to use the Pbkdf2 method
            // The method needs to use a struct field of the HashAlgorithmName type to hash the password with the salt
            
            string HashPasword(string password, out byte[] salt) 
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

            var hash = HashPasword(plainTextPassword, out byte[] salt);
            //output parameter. the out keyword is used to pass a reference
            Console.WriteLine($"Password hash: {hash}");
            Console.WriteLine($"Generated salt: {Convert.ToHexString(salt)}");
            
            bool verified = new Verify().VerifyPassword(plainTextPassword, hash, salt, hashAlgorithm);
            if (verified) //The object will return true if the password is correct. it is compared to the hashed and salted password file 
            {
                Console.WriteLine("Access Granted");
            }
        }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter a password: ");
            string plainTextPassword = Console.ReadLine();

            try
            {
                if (plainTextPassword == null)
                {
                    throw new ArgumentNullException(nameof(plainTextPassword) + " is null.");
                }
                else if (plainTextPassword.Length < 8 && plainTextPassword.Length > 24)
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
                Console.WriteLine($"The password hashing failed. {e}");
            }
            
        }
    }
}