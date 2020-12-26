using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingMarket.WebUI.EmailServer
{
   public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string htmlmessage);
     
    }
}
