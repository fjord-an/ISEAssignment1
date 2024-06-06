namespace ISEAssignment1;

static class InputArea
{
    public static Tuple<int, string> Prompt()
    {
        // Reference: C# Tutorial - Try Catch Block | Mosh. (2015)
        try //Exceptions | LinkedIn Learning. (2023). Retrieved 5 June 2024, from https://www.linkedin.com/learning/learning-c-sharp-8581491/exceptions?resume=false&u=56744473
        {
            var input = int.Parse(Console.ReadLine());
            return new Tuple<int, string>(input, null);
        }
        catch (Exception e)
        {
            return new Tuple<int, string>(0, e.Message);
        }
    }
}