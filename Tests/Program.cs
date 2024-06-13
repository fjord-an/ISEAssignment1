using System;
using System.Threading.Tasks;
class Program
{
    public static async Task Main()
    {
        Console.WriteLine("Starting Task 1...");
        var task1 = DoSomethingAsync(3000);
        Console.WriteLine("Starting Task 2...");
        var task2 = DoSomethingAsync(2000);
        await Task.WhenAll(task1, task2);
        Console.WriteLine("Both tasks completed.");
    }
    private static async Task DoSomethingAsync(int milliseconds)
    {
        await Task.Delay(milliseconds);
        Console.WriteLine($"Task completed after {milliseconds} milliseconds");
    }
}