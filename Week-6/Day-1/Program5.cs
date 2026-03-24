/*
Problem 5 Level-2: Application Tracing for Order Processing
Scenario
An e-commerce application processes customer orders. Sometimes the order processing fails, but developers are unable to identify where the failure occurs. The team decides to implement Tracing to monitor the execution flow and diagnose the issue.
Requirements
•	Create a console application that simulates order processing.
•	The order processing should include the following steps:
o	Validate Order
o	Process Payment
o	Update Inventory
o	Generate Invoice
•	Use Trace class to log messages at each step of the process.
•	Display trace messages showing the execution flow.
Technical Constraints
•	Use System.Diagnostics.Trace.
•	Write trace messages using:
o	Trace.WriteLine()
o	Trace.TraceInformation()
•	Configure a TextWriterTraceListener to store trace logs in a file.
•	Implement the solution using .NET console application.
Expectations
•	The application should log messages for each stage of order processing.
•	Trace logs should help developers identify where failures occur.
•	The trace output should be stored in a log file.
Learning Outcome
Students will learn how to:
•	Implement application tracing using System.Diagnostics.
•	Monitor application flow using Trace listeners.
•	Use trace logs to diagnose runtime issues in real-world applications.
*/
using System;
using System.Diagnostics;
using System.IO;

class Program
{
    static void Main()
    {
        // Configure Trace to write logs into file
        Trace.Listeners.Add(new TextWriterTraceListener("log.txt"));
        Trace.AutoFlush = true;

        try
        {
            Trace.TraceInformation("Order Processing Started");

            ValidateOrder();
            ProcessPayment();
            UpdateInventory();
            GenerateInvoice();

            Trace.TraceInformation("Order Processing Completed Successfully");
        }
        catch (Exception ex)
        {
            Trace.WriteLine("Error occurred: " + ex.Message);
        }

        Console.WriteLine("Process completed. Check log.txt for trace output.");
    }

    static void ValidateOrder()
    {
        Trace.WriteLine("Step 1: Validating Order...");
        // Simulate success
    }

    static void ProcessPayment()
    {
        Trace.WriteLine("Step 2: Processing Payment...");
        // Simulate error (for testing)
        // throw new Exception("Payment failed!");
    }

    static void UpdateInventory()
    {
        Trace.WriteLine("Step 3: Updating Inventory...");
    }

    static void GenerateInvoice()
    {
        Trace.WriteLine("Step 4: Generating Invoice...");
    }
}