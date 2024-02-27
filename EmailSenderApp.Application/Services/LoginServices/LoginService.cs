﻿using EmailSenderApp.Domain.Entities.Models;
using EmailSenderApp.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace EmailSenderApp.Application.Services.LoginServices
{
    public class LoginService : ILoginService
    {

        private readonly ApplicationDbContext _contex;
        private readonly IConfiguration _config;
        public LoginService(ApplicationDbContext context, IConfiguration configuration)
        {
            _config = configuration;
            _contex = context;


        }

        public async Task<bool> IsCorrect(string useremail, string password)
        {
            var listUsers = await _contex.Users.ToListAsync();
            foreach (var user in listUsers)
            {
                if (user.UserEmail == useremail && user.UserPassword == password) return true;
            }
            return false;
        }

        public async Task<string> SendMessage(string useremail, string password)
        {
            var Log = new LoginService(_contex, _config);

            if (Log.IsCorrect(useremail, password).Result)
            {
                var userAdd = new EmailModel
                {
                    Email = useremail,
                    Password = password,
                    Code = "2270611"

                };

                await _contex.EmailChecks.AddAsync(userAdd);
                _contex.SaveChanges();
                var emailSettings = _config.GetSection("EmailSettings");

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(emailSettings["Sender"], emailSettings["SenderName"]),
                    Subject = "Code",
                    Body = userAdd.Code,
                    IsBodyHtml = true,

                };
                mailMessage.To.Add(useremail);

                using var smtpClient = new SmtpClient(emailSettings["EmailServer"], int.Parse(emailSettings["MailPort"]))
                {
                    Port = Convert.ToInt32(emailSettings["MailPort"]),
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new NetworkCredential(emailSettings["Sender"], emailSettings["Password"]),
                    EnableSsl = true,
                };




                await smtpClient.SendMailAsync(mailMessage);
                return "We sent a code. Please go to check and confirm it!";
            }
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            return "Something went wrong try again";
        }

    }
}
