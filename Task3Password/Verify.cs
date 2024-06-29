using System.Security.Cryptography;

namespace Task3Password;

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