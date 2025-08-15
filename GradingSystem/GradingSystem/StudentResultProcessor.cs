using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradingSystem
{
    public class StudentResultProcessor
    {
        
        public List<Student> ReadStudentsFromFile(string inputFilePath)
        {
            List<Student> students = new List<Student>();

            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');

                    
                    if (parts.Length != 3)
                    {
                        throw new MissingFieldException($"Incomplete data in line: \"{line}\"");
                    }

                    
                    string idPart = parts[0].Trim();
                    string namePart = parts[1].Trim();
                    string scorePart = parts[2].Trim();

                    
                    if (!int.TryParse(idPart, out int id))
                    {
                        throw new FormatException($"Invalid ID format in line: \"{line}\"");
                    }

                    
                    if (!int.TryParse(scorePart, out int score))
                    {
                        throw new InvalidScoreFormatException($"Invalid score format in line: \"{line}\"");
                    }

                    
                    students.Add(new Student(id, namePart, score));
                }
            }

            return students;
        }

       
        public void WriteReportToFile(List<Student> students, string outputFilePath)
        {
            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                foreach (var student in students)
                {
                    writer.WriteLine($"{student.FullName} (ID: {student.Id}): Score = {student.Score}, Grade = {student.GetGrade()}");
                }
            }
        }
    }
}
