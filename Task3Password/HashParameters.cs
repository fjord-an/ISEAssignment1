using System.Security.Cryptography;

namespace Task3Password;

public class HashParameters
{ // This class is used to store the parameters for the password hashing algorithm
    public const int KeySize = 64;          // Hashed key size in bytes
    public const int Iterations = 350000;   // Number of hash iterations to perform on the password
}