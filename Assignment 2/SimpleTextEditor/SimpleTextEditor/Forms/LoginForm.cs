using SimpleTextEditor.Assets;
using SimpleTextEditor.Classes;
using SimpleTextEditor.Forms;
using SimpleTextEditor.Interfaces;
using SimpleTextEditor.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleTextEditor
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            IFileManager fileManager = FileManager.GetFileManagerInstance();
            Session session = new Session(fileManager);
            session.Login(userTxtbx.Text, passTxt.Text);

            if (session.LoginSuccessful)
            {
                TextEditorForm textEditorform = new TextEditorForm(session.Token, session.User);
                this.Hide();
                textEditorform.Show();
            }
            else
            {
                MessageBox.Show(CONSTANTS.LOGIN_ERROR_MESSAGE, CONSTANTS.CAPTION_LOGIN_ERROR_MESSAGE);
            }
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void NewUserBtn_Click(object sender, EventArgs e)
        {
            NewUserForm newUserForm = new NewUserForm(this);
            this.Hide();
            newUserForm.Show(); 
        }
    }
}
