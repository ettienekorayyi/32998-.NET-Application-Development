using SimpleBankManagementSystems.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBankManagementSystems.Interfaces
{
    interface IEmail
    {
        Task SendEmail(User user, int accountNumber, string subject);
    }
}
