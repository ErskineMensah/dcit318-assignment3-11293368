using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradingSystem
{
    public class InvalidScoreFormatException : Exception
    {
        public InvalidScoreFormatException(string message) : base(message)
        {
        }
    }
}
