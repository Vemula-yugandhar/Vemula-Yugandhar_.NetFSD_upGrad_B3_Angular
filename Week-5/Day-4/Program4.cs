using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            Console.Write("Enter root directory path: ");
            string path = Console.ReadLine();

            DirectoryInfo dir = new DirectoryInfo(path);

            if (!dir.Exists)
            {
                Console.WriteLine("Invalid directory!");
                return;
            }

            DirectoryInfo[] subDirs = dir.GetDirectories();

            foreach (var sub in subDirs)
            {
                int fileCount = sub.GetFiles().Length;

                Console.WriteLine($"Folder: {sub.Name}");
                Console.WriteLine($"Files: {fileCount}");
                Console.WriteLine("-------------------");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}