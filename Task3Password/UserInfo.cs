namespace Task3Password;

class UserInfo
{
    public static string GetUserName(string userName, string hashedPassword)
    {
        Console.WriteLine("Enter your username:");
        userName = Console.ReadLine();
        hashedPassword = "";

        FileInfo fi = new FileInfo("database.txt"); // FileInfo is used to create a new file

        if (!fi.Exists)
        {
            using (FileStream fs = File.Create(fi.FullName))
                // encapsulates a FileStream object within a using statement to ensure that the file is closed 
                // and disposed of properly when the code block is exited. This allows the FileStream below
                // to access the file without any issues.
            {
                Console.WriteLine("The database does not exist, creating a new one");
            }
        }
        
        StreamReader sr = new StreamReader(fi.FullName); // StreamReader is used to read from a file.
        //https://learn.microsoft.com/en-us/troubleshoot/developer/visualstudio/csharp/language-compilers/read-write-text-file
            
        if (fi.Exists) // if the file does not exist, create it. This ensures that the file is created before writing to it.
        {
            using (StreamReader fs = new StreamReader(fi.FullName))
            {
                // code adapted from:
                //Ashutosh, G. (2019, November 29). How do I read a specific line in a text file and compare it with a string?
                //- CodeProject. https://www.codeproject.com/Questions/5252393/How-do-I-read-a-specific-line-in-a-text-file-and-c
                    
                Console.WriteLine("Looking for Account...");
                int counter = 0;        // counter is used to keep track of the line number
                string line;            // line is used to store the current line being read from the file

                while ((line = fs.ReadLine()) != null)
                    // ensures the line is correct, and not at the end of the file. In which case it would be null.
                {
                    if (string.Equals(userName, line.Split(':')[0], StringComparison.OrdinalIgnoreCase))
                        //using the type StringComparison.OrdinalIgnoreCase overload will ignore case sensitivity
                        //Because the database is set up as username:hashedpassword, the split method is used to
                        //separate the username from the hashed password
                    {
                        Console.WriteLine("User found!");
                        return line;
                    }
                    counter++;
                }
                return "User not found";
            }
        }
        return "User Error";
    }
}