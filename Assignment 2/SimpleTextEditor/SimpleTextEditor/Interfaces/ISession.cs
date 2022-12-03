using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTextEditor.Interfaces
{
    public interface ISession
    {
        void Login(string username, string password);
        IUserProfile User { get; set; }
    }
}
