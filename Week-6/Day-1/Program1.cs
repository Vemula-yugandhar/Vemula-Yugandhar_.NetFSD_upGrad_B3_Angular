/*Level-1 Problem 1: Asynchronous File Logger
Scenario:
 An application writes logs to a file whenever an event occurs. Writing logs synchronously can slow down the application. Asynchronous file writing improves performance.
 
Requirements:
 - Create an asynchronous method WriteLogAsync(string message).
 - The method should simulate file writing using Task.Delay().
 - Call this method multiple times to simulate logging different events.
 
Technical Constraints:
 - Use async and await keywords.
 - Use Task.Delay() to simulate file I/O.
 - Use a console application.
 
Expectations:
 - Logs should be written asynchronously.
 - The main thread should remain responsive while logging operations occur.
 
Learning Outcome:
 Students will learn how asynchronous operations improve performance when dealing with I/O operations.
*/
using System;
using System.Threading.Tasks;

class Program
{
    // Async method to simulate file logging
    static async Task WriteLogAsync(string message)
    {
        Console.WriteLine($"Start writing: {message}");

        // Simulate file writing delay
        await Task.Delay(2000);

        Console.WriteLine($"Finished writing: {message}");
    }

    static async Task Main()
    {
        Console.WriteLine("Logging started...\n");

        // Calling async methods multiple times
        Task t1 = WriteLogAsync("Log 1");
        Task t2 = WriteLogAsync("Log 2");
        Task t3 = WriteLogAsync("Log 3");

        Console.WriteLine("Main thread is free...\n");

        // Wait for all logs to complete
        await Task.WhenAll(t1, t2, t3);

        Console.WriteLine("\nAll logs completed.");
    }
}