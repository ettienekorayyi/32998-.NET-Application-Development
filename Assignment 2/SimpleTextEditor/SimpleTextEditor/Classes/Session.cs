using SimpleTextEditor.Assets;
using SimpleTextEditor.Interfaces;
using SimpleTextEditor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleTextEditor.Classes
{
    public class Session : ISession
    {
        private IFileManager _fileManager;
        private Guid _token;
        private bool _loginSuccessful;
        private IUserProfile _user;

        public Guid Token
        { 
            get { return _token; }
            set { _token = value; }
        }

        public IUserProfile User
        {
            get { return _user; }
            set { _user = value; }
        }

        public bool LoginSuccessful
        {
            get { return _loginSuccessful; }
            private set { _loginSuccessful = value; }
        }

        public Session(IFileManager fileManager)
        {
            _fileManager = fileManager;
        }

        public void Login(string username, string password)
        {
            _fileManager.OpenFile();
            List<IUserProfile> users = _fileManager.ReadFile();
            var result = this.ValidateCredentials(users, username, password);

            switch (result)
            {
                case true:
                    Token = Guid.NewGuid();
                    LoginSuccessful = result;
                    break;
                default:
                    LoginSuccessful = result;
                    break;
            }
        }

        private bool ValidateCredentials(List<IUserProfile> users, string username, string password)
        {
            foreach (IUserProfile user in users)
            {
                if (user.UserName == username && user.Password == password)
                {
                    _user = new UserProfile()
                    { 
                        UserName = user.UserName,
                        UserType = user.UserType,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        DateOfBirth = user.DateOfBirth,
                    };
                    return true;
                }
                else continue;
            }

            return false;
        }
    }

}
