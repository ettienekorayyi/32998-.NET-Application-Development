using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTextEditor.Classes
{
    public class State
    {
        FileStream fStream;

        public State(FileStream fStream)
        {
            this.fStream = fStream;
        }

        public FileStream FStream
        { 
            get { return fStream; } 
        }
    }
}
