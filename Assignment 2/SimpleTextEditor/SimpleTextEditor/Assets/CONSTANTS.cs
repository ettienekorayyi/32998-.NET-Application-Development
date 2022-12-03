using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTextEditor.Assets
{
    public static class CONSTANTS
    {
        // File Type Filters
        public const string EXTENSION_FILE_FILTER = "txt files (*.txt)|*.txt|(*.rtf)|*.rtf";
        public const string EXTENSION_TYPE_TXT = ".txt";

        // Directories
        public const string LOGIN_FILE = "login.txt";
        public const string TEXT_FILE = "stv.txt";
        public const string FILE_PATH = @"Assets\Files\";
        public static string BASE_DIRECTORY = AppDomain.CurrentDomain.BaseDirectory.Replace(@"\bin\Debug", String.Empty);

        // Captions
        public static string CAPTION_DUPLICATE_ERROR_MESSAGE_TITLE = "WARNING!";

        // Error Messages
        public static string LOGIN_ERROR_MESSAGE = "Your Username/Password is Invalid.";
        public static string CAPTION_LOGIN_ERROR_MESSAGE = "Unauthorized Access Denied!";
        public static string TEXT_DUPLICATE_ERROR_MESSAGE = "Duplicate username is not allowed.";
        public static string USER_TYPE_VIEW = "View";

        public static string LOGGED_USER_TEXT = "Username: ";

        // Regex Strings
        public static string REMOVE_RTF_STRINGS = @"\{\*?\\[^{}]+}|[{}]|\\\n?[A-Za-z]+\n?(?:-?\d+)?[ ]?";
        public static string REMOVE_RTF_CARRIAGE_RETURN = @"\r\n";

    }

    public enum Dialog
    {
        OpenFileDialog,
        SaveFileDialog,
    }
}
