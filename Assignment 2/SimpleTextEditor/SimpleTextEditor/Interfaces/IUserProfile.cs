using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTextEditor.Interfaces
{
    public interface IUserProfile
    {
        String UserName 
        {
            get;
            set;
        }

        String Password 
        { 
            get; set; 
        }
        
        String ConfirmPassword 
        { 
            get; set; 
        }
        String FirstName
        { 
            get; set; 
        }
        
        String LastName 
        { 
            get; set; 
        }
        
        DateTime DateOfBirth 
        { 
            get; set; 
        }
        
        String UserType 
        { 
            get; set; 
        }
    }
}
