using System;
using System.Collections.Generic;
using System.IO;

namespace GradingSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
       
            string inputFilePath = "students.txt";       
            string outputFilePath = "report.txt";

            if (!File.Exists(inputFilePath))
            {
                using (StreamWriter sw = new StreamWriter(inputFilePath))
                {
                    sw.WriteLine("101, Alice Smith, 84");
                    sw.WriteLine("102, John Doe, 72");
                    sw.WriteLine("103, Mary Johnson, 65");
                    sw.WriteLine("104, Tom Brown, 58");
                    sw.WriteLine("105, Sarah White, 45");
                }
                Console.WriteLine("Dummy students.txt file created with sample data.");
            }

            StudentResultProcessor processor = new StudentResultProcessor();

            //Whole process wrapped in a try-catch block
            try
            {
                // Read students from the input file
                List<Student> students = processor.ReadStudentsFromFile(inputFilePath);

                // Write report to the output file
                processor.WriteReportToFile(students, outputFilePath);

                Console.WriteLine("Report successfully generated!");
                Console.WriteLine($"Output file: {Path.GetFullPath(outputFilePath)}");
            }
            // Catch FileNotFoundException if the input file is missing
            catch (FileNotFoundException)
            {
                Console.WriteLine($"Error: Input file not found at {Path.GetFullPath(inputFilePath)}");
            }
            // Catch InvalidScoreFormatException if score is not an integer
            catch (InvalidScoreFormatException ex)
            {
                Console.WriteLine($"Score Format Error: {ex.Message}");
            }
            // Catch MissingFieldException if a record has missing data
            catch (MissingFieldException ex)
            {
                Console.WriteLine($"Missing Field Error: {ex.Message}");
            }
            // Catch any other unforeseen errors
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected Error: {ex.Message}");
            }
        }
    }
}
