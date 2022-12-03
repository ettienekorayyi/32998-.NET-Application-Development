using SimpleBankManagementSystems.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBankManagementSystems.Interfaces
{
    interface IFileManager
    {
        string[] OpenFile();
        bool CreateFile(User user);
        int GetAccountNumberFromFileName();
        User FindAccount(User user);
        bool CheckFileExists(int accountNumber);
        User UpdateAccount(User user, string operation);
        User GetAccountStatement(User user);
        void Delete(User user);
    }
}
