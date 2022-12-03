using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleTextEditor.Assets;

namespace SimpleTextEditor.Classes
{
    public class DialogFactory
    {
        public static FileDialog CreateDialog(Dialog dialog)
        {
            switch (dialog)
            {
                case Dialog.OpenFileDialog:
                    return new OpenFileDialog();
                case Dialog.SaveFileDialog:
                    return new SaveFileDialog()
                    {
                        Filter = "txt files (*.rtf)|*.rtf|(*.txt)|*.txt",
                        Title = "Save As",
                        RestoreDirectory = true,
                        FilterIndex = 2
                    };
                default:
                    return null;
            }
        }
    }
}
