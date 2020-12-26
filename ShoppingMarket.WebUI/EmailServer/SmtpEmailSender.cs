using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ShoppingMarket.WebUI.EmailServer
{
    public class SmtpEmailSender : IEmailSender
    {
        string _host;
        int _port;
        bool _enabledSSL;
        string _username;
        string _password;
        public SmtpEmailSender(string host,int port,bool enabledSSL,string username,string password)
        {
            this._host = host;
            this._port = port;
            this._enabledSSL = enabledSSL;
            this._username = username;
            this._password = password;
        }
        public Task SendEmailAsync(string email, string subject, string htmlmessage)
        {
            var client = new SmtpClient(this._host,this._port)
            {
                Credentials = new NetworkCredential(_username, _password),
                EnableSsl = this._enabledSSL
            };
            return client.SendMailAsync(
                new MailMessage(this._username, email, subject, htmlmessage)
                {
                    IsBodyHtml = true
                }
                ); 
        }
    }
}
