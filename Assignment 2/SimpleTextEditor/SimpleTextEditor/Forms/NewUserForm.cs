using SimpleTextEditor.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SimpleTextEditor.Model;
using SimpleTextEditor.Classes;
using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using SimpleTextEditor.Assets;

namespace SimpleTextEditor.Forms
{
    public partial class NewUserForm : Form
    {
        private Form _form;
        private bool _saved = false;
        
        public NewUserForm(Form form)
        {
            _form = form;
            InitializeComponent();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            _form.Show();
        }

        private void SubmitBtn_Click(object sender, EventArgs e)
        {
            try
            {
                IUserProfile userProfile = new UserProfile()
                {
                    UserName = userTxtBx.Text,
                    Password = passTxtBx.Text,
                    ConfirmPassword = confirmPassTxtBx.Text,
                    FirstName = firstNameTxtBx.Text,
                    LastName = lastNameTxtBx.Text,
                    DateOfBirth = dateOfBirthPicker.Value,
                    UserType = userTypeComboBx.SelectedItem.ToString()
                };
                IFileManager fileManager = FileManager.GetFileManagerInstance();
                fileManager.SaveFile(userProfile);
                _saved = true;
            }
            catch (NullReferenceException nex)
            {
                Debug.WriteLine(nex);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Debug.WriteLine(ex);
            }

            this.Hide();
            _form.Show();
        }

        private void logOutToolStripNewUser_Click(object sender, EventArgs e)
        {
            CheckFields();
            _saved = true;
            this.Hide();
            _form.Show();
        }

        private void NewUserForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void CheckFields()
        {
            try
            {
                if (
                    userTxtBx.Text != String.Empty                          && 
                    passTxtBx.Text != String.Empty                          && 
                    confirmPassTxtBx.Text != String.Empty                   &&
                    firstNameTxtBx.Text != String.Empty                     && 
                    lastNameTxtBx.Text != String.Empty                      && 
                    dateOfBirthPicker.Value != DateTime.MaxValue            && 
                    userTypeComboBx.SelectedItem.ToString() != String.Empty &&
                    _saved != true
                )
                {
                    IUserProfile userProfile = new UserProfile()
                    {
                        UserName = userTxtBx.Text,
                        Password = passTxtBx.Text,
                        ConfirmPassword = confirmPassTxtBx.Text,
                        FirstName = firstNameTxtBx.Text,
                        LastName = lastNameTxtBx.Text,
                        DateOfBirth = dateOfBirthPicker.Value,
                        UserType = userTypeComboBx.SelectedItem.ToString()
                    };

                    IFileManager fileManager = FileManager.GetFileManagerInstance();
                    fileManager.SaveFile(userProfile);
                }
            }
            catch (NullReferenceException nex)
            {
                Debug.WriteLine(nex);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void userTxtBx_TextChanged(object sender, EventArgs e)
        {
            IFileManager fileManager = FileManager.GetFileManagerInstance();
            fileManager.OpenFile();
            var read = fileManager.ReadFile();
            foreach (var profile in read)
            {
                if (profile.UserName == userTxtBx.Text)
                {
                    MessageBox.Show(CONSTANTS.TEXT_DUPLICATE_ERROR_MESSAGE, CONSTANTS.CAPTION_DUPLICATE_ERROR_MESSAGE_TITLE);
                    userTxtBx.Text = String.Empty;
                    break;
                }
            }
        }

        private void confirmPassTxtBx_Leave(object sender, EventArgs e)
        {
            if (confirmPassTxtBx.Text != passTxtBx.Text)
            {
                MessageBox.Show("Password does not match", "Warning", MessageBoxButtons.OK);
                confirmPassTxtBx.Text = string.Empty;
            }
        }
    }
}
