using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBankManagementSystems.Model
{
    class AccountStatement
    {
        public string Date { get; set; }
        public string Transaction { get; set; }
        public string TransactionAmount { get; set; }
        public string Balance { get; set; }
    }
}
