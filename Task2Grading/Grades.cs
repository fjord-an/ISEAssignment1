namespace Task2Grading;

public static class Grades
{
    public static string Classifications(byte score)
    {
        return score switch
        {
            /* new switch expression syntax in C# 8.0 can return a value, perfect for clean and concise code
            and good for this use case.
            source: Z, D. (2019, September 6). Answer to ‘Combine return and switch in C#’. Stack Overflow.
            https://stackoverflow.com/a/57819758
            */
            
            >100 => "Invalid",
            >85 => "High Distinction",
            >75 => "Distinction",
            >65 => "Credit",
            >55 => "Pass",
            >0 => "Fail",
        };
    }
}