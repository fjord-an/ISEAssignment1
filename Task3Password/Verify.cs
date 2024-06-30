using System.Security.Cryptography;

namespace Task3Password;

public class Verify // #####################SOURCE VERIFY????
{
    internal static void Login(string userName, string plainTextPassword, string hash, byte[] salt, HashAlgorithmName hashAlgorithm)
    { 
        bool verified = new Verify().VerifyPassword(plainTextPassword, hash, salt, hashAlgorithm);
        if (verified) 
        {
            UserArea.UserPage(userName);
        }
    }
    
    // The verification method is used to compare the hashed and salted password to the user's input and return a boolean
    // value to determine if the password is correct. This can be used to grant access to the users data
    // if the password is correct
    public bool VerifyPassword(string password, string hash, byte[] salt, HashAlgorithmName hashAlgorithm)
    {
                
        // Hash the password and salt using the same key derivation function to compare the hashes
        var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(password, salt, HashParameters.Iterations, hashAlgorithm,
            HashParameters.KeySize);
        //The cryptographic verification object will return true if the password is correct. it is compared to the
        //hashed and salted password file 
        
        //return the result of the comparison of the two hashes using the CryptographicOperations.FixedTimeEquals method
        //??? Create a fixed-time comparison to prevent timing attacks???
        
        return CryptographicOperations.FixedTimeEquals(hashToCompare, Convert.FromHexString(hash));
    }// The CryptographicOperations.FixedTimeEquals method is used to compare the hash to prevent timing attacks
    // This is good practice for password hashing to prevent attackers from guessing the password based on the
    // time it takes to compare the hashes
}