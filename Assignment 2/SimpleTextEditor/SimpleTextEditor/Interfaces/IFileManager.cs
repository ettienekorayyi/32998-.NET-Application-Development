using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTextEditor.Interfaces
{
    public interface IFileManager
    {
        void OpenFile();
        void SaveFile(IUserProfile userProfile);
        List<IUserProfile> ReadFile();
        
    }
}
