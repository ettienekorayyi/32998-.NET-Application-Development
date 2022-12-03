using SimpleTextEditor.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTextEditor.Model
{
    public class UserProfile : IUserProfile
    {
        private string _username;
        private string _password;
        private string _confirmPassword;
        private string _firstName;
        private string _lastName;
        private DateTime _dateOfBirth;
        private string _userType;

        public string UserName 
        {
            get { return _username; }
            set { _username = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public string ConfirmPassword
        {
            get { return _confirmPassword; }
            set { _confirmPassword = value; }
        }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string LastName 
        {
            get { return _lastName; }
            set { _lastName = value; }
        }
        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set { _dateOfBirth = value; }
        }
        public string UserType
        {
            get { return _userType; }
            set { _userType = value; }
        }
    }
}
