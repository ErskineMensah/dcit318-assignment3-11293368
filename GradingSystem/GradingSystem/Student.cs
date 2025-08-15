using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradingSystem
{
    public class Student
    {
        public int Id { get; }
        public string FullName { get; }
        public int Score { get; }

        public Student(int id, string fullName, int score)
        {
            Id = id;
            FullName = fullName;
            Score = score;
        }

        // Method to determine grade based on score
        public string GetGrade()
        {
            if (Score >= 80 && Score <= 100)
                return "A";
            else if (Score >= 70 && Score <= 79)
                return "B";
            else if (Score >= 60 && Score <= 69)
                return "C";
            else if (Score >= 50 && Score <= 59)
                return "D";
            else
                return "F";
        }
    }
}
