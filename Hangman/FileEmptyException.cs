using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman {
    public class FileEmptyException : Exception {
        public FileEmptyException(string message) : base(message) { 
            
        }
    }
}
