﻿using CarrierAPI.Application.Abstractions.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CarrierAPI.Infrastructure.Service
{
    public class MailService : IMailService
    {
        readonly IConfiguration _configuration;

        public MailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendMailAsync(string to, string subject, string body, bool isBodyHtml = true)
        {
            await SendMailAsync(new[] { to }, subject, body, isBodyHtml);
        }

        public async Task SendMailAsync(string[] tos, string subject, string body, bool isBodyHtml = true)
        {
            MailMessage mail = new();
            mail.IsBodyHtml = isBodyHtml;
            foreach (var to in tos)
            {
                mail.To.Add(to);
                mail.Subject=subject;
                mail.Body=body;
                mail.From = new(_configuration["Mail:Username"], "Test-Carrier", System.Text.Encoding.UTF8);

                SmtpClient smtp = new();
                smtp.Credentials = new NetworkCredential(_configuration["Mail:Username"], _configuration["Mail:Password"]);
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Host = _configuration["Mail:Host"];
              //  await smtp.SendMailAsync(mail);

            }
        }
    }
}
