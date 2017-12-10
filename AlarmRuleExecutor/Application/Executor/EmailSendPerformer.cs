using System;
using System.Net;
using System.Net.Mail;
using System.Web;
using AlarmRuleExecutor.Application.Configuration;
using AlarmRuleExecutor.Application.Data;
using AlarmRuleExecutor.Application.Dto;
using AlarmRuleExecutor.Application.Entity;
using Newtonsoft.Json;

namespace AlarmRuleExecutor.Application.Executor
{
    public class EmailSendPerformer:ActionPerformer
    {
        private readonly IElasticSearchManager manager;
        private readonly EmailSettings settings;
        private static SmtpClient _client;
        private static readonly object _lock = new object();

        public EmailSendPerformer(IElasticSearchManager manager,EmailSettings settings)
        {
            this.manager = manager;
            this.settings = settings;
            if (_client == null)
                _client = new SmtpClient
                {
                    Host = settings.Host,
                    Port = settings.Port,
                    EnableSsl = settings.EnableSsl,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(settings.Username, settings.Password)
                };
        }

        public override bool Perform(SensorDto dto, string jsonMessage)
        {
            var email = JsonConvert.DeserializeObject<Email>(jsonMessage);
            if (email == null) return false;
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(settings.From);
            mailMessage.To.Add(email.To);
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = GetBodyString(email.Body,dto);
            mailMessage.Subject = email.Subject??"Sensor value changed!";
            lock (_lock)
            {              
                try
                {
                    _client.Send(mailMessage);
                }
                catch (Exception ex)
                {
                    manager.Log("logs", "exception", ex);
                }
            }

            return true;
        }

        private string GetBodyString(string content, SensorDto dto)
        {
            content=HttpUtility.UrlDecode(content);
            content = content.Replace("[SensorName]", dto.Name);
            content = content.Replace("[SensorValue]", dto.Value);
            content = content.Replace("[ActionDate]", dto.CreationTime.ToString("F"));
            return content;
        }
    }
}
