using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleTextEditor.Classes
{
    public static class StreamExtension
    {
        public static bool StreamState(this Stream state)
        {
            return state != null ? true : false;
        }
    }
}
