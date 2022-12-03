using SimpleTextEditor.Assets;
using SimpleTextEditor.Classes;
using SimpleTextEditor.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SimpleTextEditor.Forms
{
    public partial class TextEditorForm : Form
    {
        private Guid _token;
        private FileDialog _fileDialog;
        private Stream _fileStream;
        private IUserProfile _user;
        private FileInfo _fileInfo;

        public TextEditorForm(Guid token, IUserProfile user)
        {
            _token = token;
            _user = user;
            InitializeComponent();
        }

        private void TextEditorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// The Regex code below cleans the rtf strings when opening 
        /// a file with .rtf extension.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string unformatted = String.Empty;
            using (_fileDialog = (OpenFileDialog)DialogFactory.CreateDialog(Dialog.OpenFileDialog)) 
            {
                _fileDialog.InitialDirectory = $"{CONSTANTS.BASE_DIRECTORY}{CONSTANTS.FILE_PATH}";
                _fileDialog.Filter = CONSTANTS.EXTENSION_FILE_FILTER;
                
                if (_fileDialog.ShowDialog() == DialogResult.OK)
                {
                    _fileInfo = new FileInfo(_fileDialog.FileName);
                    _fileStream = ((OpenFileDialog)_fileDialog).OpenFile();
                    
                    using (StreamReader reader = new StreamReader(_fileStream))
                    {
                        unformatted = Regex.Replace(reader.ReadToEnd(),CONSTANTS.REMOVE_RTF_STRINGS, string.Empty);
                        var formatted = Regex.Replace(unformatted, CONSTANTS.REMOVE_RTF_CARRIAGE_RETURN, string.Empty);
                        richTextBox.Text = formatted;
                    }
                }
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _fileDialog = (SaveFileDialog)DialogFactory.CreateDialog(Dialog.SaveFileDialog);
            
            if (_fileDialog.ShowDialog() == DialogResult.OK)
            {
                if (_fileInfo.Extension == CONSTANTS.EXTENSION_TYPE_TXT)
                {
                    richTextBox.SaveFile(_fileDialog.FileName, RichTextBoxStreamType.PlainText);
                }
                else
                {
                    richTextBox.SaveFile(_fileDialog.FileName, RichTextBoxStreamType.RichText);
                }
            }
        }

        /// <summary>
        /// This function behaves like Save when you do not want to change 
        /// the name and location of the document. It also behaves like a Save as 
        /// when you want to change the name, location and format of the document
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            if (_fileStream.StreamState() == true)
            {
                State state = new State((FileStream)_fileStream);

                if (_fileInfo.Extension == CONSTANTS.EXTENSION_TYPE_TXT)
                {
                    richTextBox.SaveFile(state.FStream.Name, RichTextBoxStreamType.PlainText);
                }
                else
                {
                    richTextBox.SaveFile(state.FStream.Name, RichTextBoxStreamType.RichText);
                }
            }
            else
            {
                _fileDialog = (SaveFileDialog)DialogFactory.CreateDialog(Dialog.SaveFileDialog);

                if (_fileDialog.ShowDialog() == DialogResult.OK && _fileStream.StreamState() == false)
                {
                    _fileInfo = new FileInfo(_fileDialog.FileName);
                    if (_fileInfo.Extension == CONSTANTS.EXTENSION_TYPE_TXT)
                    {
                        richTextBox.SaveFile(_fileDialog.FileName, RichTextBoxStreamType.PlainText);
                    }
                    else
                    {
                        richTextBox.SaveFile(_fileDialog.FileName, RichTextBoxStreamType.RichText);
                    }
                }
            }
        }

        private void boldToolStripButton_Click(object sender, EventArgs e)
        {
            Font newFont;
            Font oldFont = richTextBox.SelectionFont;
            if (oldFont.Italic) newFont = new Font(oldFont, oldFont.Style & ~FontStyle.Bold);
            else newFont = new Font(oldFont, oldFont.Style | FontStyle.Bold);

            richTextBox.SelectionFont = newFont;
            
        }

        private void italicToolStripButton_Click(object sender, EventArgs e)
        {
            Font newFont;
            Font oldFont = richTextBox.SelectionFont;
            if(oldFont.Italic) newFont = new Font(oldFont, oldFont.Style & ~FontStyle.Italic);
            else newFont = new Font(oldFont, oldFont.Style | FontStyle.Italic);

            richTextBox.SelectionFont = newFont;

        }

        private void underlineToolStripButton_Click(object sender, EventArgs e)
        {
            Font newFont;
            Font oldFont = richTextBox.SelectionFont;
            if (oldFont.Underline) newFont = new Font(oldFont, oldFont.Style & ~FontStyle.Underline);
            else newFont = new Font(oldFont, oldFont.Style | FontStyle.Underline);

            richTextBox.SelectionFont = newFont;
            
        }

        private void fontSizetoolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            object selectedItem = fontSizetoolStripComboBox.SelectedItem;
            Font oldFont = richTextBox.SelectionFont;
            
            if (selectedItem != null)
            {
                float fontSize = float.Parse(selectedItem.ToString());
                richTextBox.SelectionFont = new Font(oldFont.Name, fontSize, oldFont.Style);
            }
        }

        private void copyToolStripButton_Click(object sender, EventArgs e)
        {
            if (richTextBox.SelectionLength > 0) richTextBox.Copy();
        }

        private void cutToolStripButton_Click(object sender, EventArgs e)
        {
            if (richTextBox.SelectedText != "") richTextBox.Cut();
        }

        private void pasteToolStripButton_Click(object sender, EventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                richTextBox.Paste();
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.ShowDialog();
        }

        private void TextEditorForm_Load(object sender, EventArgs e)
        {
            loggedInUser.Text = $"{CONSTANTS.LOGGED_USER_TEXT}{_user.UserName}";
            
            if (_user.UserType == CONSTANTS.USER_TYPE_VIEW) richTextBox.Enabled = false;
            else richTextBox.Enabled = true;
        }

        
        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            this.Hide();
            loginForm.ShowDialog();
        }

        private void newMenuItem_Click(object sender, EventArgs e)
        {
            NewUserForm newUserForm = new NewUserForm(this);
            this.Hide();
            newUserForm.Show();
        }
    }
}
