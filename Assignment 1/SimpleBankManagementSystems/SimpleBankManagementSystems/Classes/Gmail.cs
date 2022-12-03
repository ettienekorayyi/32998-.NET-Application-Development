using SimpleBankManagementSystems.Interfaces;
using SimpleBankManagementSystems.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBankManagementSystems.Classes
{
    class Gmail : IEmail
    {
        /// <summary>
        /// I have included the credentials for my test gmail account in case the tutor needs 
        /// to access the email. 
        /// The username and password of the test email account are listed below:
        /// username: stvccorral@gmail.com
        /// password: p@ss1word
        /// </summary>
        private const string senderEmail = "stvccorral@gmail.com"; 
        private const string senderPassword = "ggdpmbnaqkzsmssf";

        /// <summary>
        /// The SendEmail is responsible for sending an email to the user using gmail
        /// during account creation and/or when requesting for the account statement.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="accountNumber"></param>
        public async Task SendEmail(User user, int accountNumber, string subject = "")
        {
            MailAddress senderAddress = new MailAddress(senderEmail, $"{user.FirstName} {user.LastName}" , System.Text.Encoding.UTF8);
            MailAddress recipientAddress = new MailAddress(user.Email);

            using (SmtpClient client = new SmtpClient())
            {
                client.Host = "smtp.gmail.com";
                client.Port = 587;
                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(senderAddress.Address, senderPassword);

                using (MailMessage message = new MailMessage(senderAddress, recipientAddress))
                {
                    message.Subject = subject;
                    string statements = String.Empty;

                    if (user.AccountStatements.Count() == 0) statements += "User has no statement.";
                    foreach (var st in user.AccountStatements)
                    {
                        statements += $"{st.Date} | {st.Transaction} | {st.TransactionAmount} | {st.Balance}\n";    
                    }

                    message.Body = $"Dear {user.FirstName}, \n\n" +
                        $"Your account details are listed below: \n" +
                        $"Account Number: {accountNumber}\n" + $"First Name: {user.FirstName}\n" +
                        $"Last Name: {user.LastName}\n" + $"Address: {user.Address}\n" +
                        $"Balance: {user.Balance}\n" + $"Phone: {user.Phone}\n" + $"Email: {user.Email}\n\n" +
                        $"Statements:\n" +
                        $"{statements}";

                    try
                    {
                        await client.SendMailAsync(message);
                    }
                    catch (SmtpException smtp)
                    {
                        Console.WriteLine(smtp.Message);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
            
        }
    }
}
