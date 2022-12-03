
# **32998 - .NET Applications Development Assignment 1: ** #
Reminders: 
- You can copy/paste this .md file into dillinger.io to preview the README.md Thank you.
- The login credentials can be located at Common > Assets > Files > login.txt
- The other text files are also located at Common > Accounts Assets > Files
## Simple Text Editor ##
Developed By: Stephen Melben Corral 
Student ID: 14394302

# Login Credentials with View Permission only: #
# ** Guest: ** #
username: user1
password: password123

# Login Credentials with Edit Permission: #
# ** User2: ** #
username: NotBatman
password: UTS2017


# The version of Visual Studio you compiled your code in #
Visual Studio 2022

# **HOW TO RUN THE APPLICATION** #
1. Open Visual Studio and select the Simple Bank Management System solution to open the file.
2. Press and hold the **_ctrl_** and **_f5_** buttons from your keyboard.

# **HOW TO LOGIN THE APPLICATION** #
**Reminder: The user credentials are case sensitive**
1. Input the username and password listed above. 
2. Click Login button. The login form should close and the text editor form should open.
3. The user should be redirected to the Text Editor form.
**Reminder: Login Users with View Permissions**
**The text editor form should be disabled.**
**The user should still be able to open a file.**

 **Reminder: Login Users with Edit Permissions**
**The text editor form should be enabled.**
**The user should still be able to open a file.**

# **CREATING A NEW USER** #
**Reminder: There are 2 ways to create a new user.**
**At the Login form**
**At the Text Editor form: File > New **

1. At the login form, click the New User button. 
2. Input user details. 
3. Click Submit
**Reminder:**
If the user clicks submit without adding the user details, the user will be redirected to the login page.
If the user clicks the log out button while in the New User form, the user details are saved in the login.txt.

# **HOW TO OPEN A FILE(.rtf and .txt)** #
1. Login with a user that has **edit permissions**.
2. Click File > Open 
**Reminder:**
To view the .rtf files click the file extension drop down besides the file name text box.

# **HOW TO SAVE A FILE(.rtf and .txt)** #
1. Login with a user that has **edit permissions**.
2. Click File > Open 
3. Change the content of the file.
4. Click File > Save or Click the Save icon
This should update the content of the file being modified.

# **HOW TO SAVE AS FILE(.rtf and .txt)** #
1. Login with a user that has **edit permissions**.
2. Click File > Open 
3. Change the content of the file.
4. Click File > Save As
5. When the Save As dialog appears, type the filename and choose the file extension.
This should allow us to create a new file.

# **HOW TO CHANGE THE FONT STYLE TO BOLD/ITALIC/UNDERLINE(.rtf and .txt)** #
1. At the Text Editor type a random text
2. Select the text and click the bold,italic or underline icon.

## ** NOTES: ** ##
The Log out button in the Text Editor does not save the user because I've already added a log out button in the New User form that saves the user details when clicked.

## ** LIMITATION: ** ##
It does not save the formatting information(ie: Bold, Italic etc.) applied to the text file's content. This is due to the text file having no formatting information.
Reference: https://stackoverflow.com/questions/29661880/write-a-string-to-a-text-file-with-a-specific-font-and-size