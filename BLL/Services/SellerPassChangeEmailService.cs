using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public  class SellerPassChangeEmailService
    {
        public static bool SendEmail(string Sname)
        {
            Random rnd = new Random();
            string randomNumber = "Your Password Has Been Change Successfully ";
            var data = DataAccessFactory.SellerData().Read(Sname);

            if (data == null)
            {
                return false;
            }

            string email = data.Email;
            var fromAddress = new MailAddress("shahriarmiraj116@gmail.com", "PCbuild");
            var toAddress = new MailAddress(email, data.Name);
            const string fromPassword = "kqaegtjcflwypwkl";
            const string subject = "Change Password Email";
            string body = randomNumber;

            using (var smtp = new SmtpClient("smtp.gmail.com", 587))
            {
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(fromAddress.Address, fromPassword);

                using (var message = new MailMessage(fromAddress, toAddress))
                {
                    message.Subject = subject;
                    message.Body = body;

                    smtp.Send(message);
                }
            }

            return true;
        }

    }
}
