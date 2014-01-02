using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Mail;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.OleDb;
using System.Data;

namespace MainForm
{
    class Mail
    {
        public static string sendMail(string recieverMailAddress, string recieverName, string messageSubject, string messageBody)
        { // method for sending mail
            try
            {
                // using a GMail account
                var fromAddress = new MailAddress("ia2013testkontoforprosjekt@gmail.com", "IA-Prosjekt-2013");
                var toAddress = new MailAddress(recieverMailAddress, recieverName);
                const string fromPassword = "passord123456789";

                // create smtp client object containing all needed info
                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };
                // create mail and send it
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = messageSubject,
                    Body = messageBody
                })
                {
                    smtp.Send(message);
                }
                // mail sendt successfully
                return "Mail sendt";
            }
            catch (Exception ex)
            {
                Error.WriteLog("sendMail", ex.Message, "");
                // something failed, return error message
                return "Error: " + ex.Message;
            }
        }
        public static void sendMailToEntireContactsList(string subject, string message)
        {
            try
            {
                // get contacts list from database
                DataTable contactsListDataTable = Database.readContactsTable();

                // sort thru the names
                string recieverMailAddress = "";
                string recieverName = "";
                foreach (DataRow row in contactsListDataTable.Rows)
                {
                    recieverName = row["Name"].ToString();
                    recieverMailAddress = row["Email"].ToString();

                    // send a mail to each entry in the contacts list
                    Mail.sendMail(recieverMailAddress, recieverName, subject, message);
                }
            }
            catch (Exception ex)
            {
                Error.WriteLog("email entire contact list", ex.Message, "");
            }
        }
    }
}
