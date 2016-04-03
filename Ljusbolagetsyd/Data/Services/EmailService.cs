using System;
using System.Net;
using System.Net.Mail;
using Ljusbolagetsyd.Models;

namespace Ljusbolagetsyd.Data.Services
{
	public static class EmailService
	{
		public static bool SendNewEmail(ContactFormViewModel model)
		{
			try
			{

				SendEmail(model,ConfigureEmailSettings());
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}

		private static EmailConfiguration ConfigureEmailSettings()
		{
			return new EmailConfiguration().FetchConfigurationForMail();
		}

		private static void SendEmail(ContactFormViewModel model, EmailConfiguration emailSettings)
		{
			var mailMessage = CreateMailMessage(model);
			mailMessage.To.Add(new MailAddress(emailSettings.Email));
			var smtpClient = CreateMailClient(emailSettings);
			smtpClient.Send(mailMessage);
		}

		private static SmtpClient CreateMailClient(EmailConfiguration emailSettings)
		{

			return new SmtpClient
			{
				Port = emailSettings.Port,
				Host = emailSettings.Host,
				DeliveryMethod = SmtpDeliveryMethod.Network,
				UseDefaultCredentials = false,
				Credentials = new NetworkCredential(emailSettings.Email, emailSettings.Password),
				EnableSsl = true
			};
		}

		private static MailMessage CreateMailMessage(ContactFormViewModel model)
		{
			var message = new MailMessage
			              {
				              Subject = "Förfrågan",
				              Body = "Avsändarens namn: " + " " +
				                     model.Name + " \r\n " + "Meddelande: " + " " +
				                     model.MessageText + "\r\n" + "Avsändarens email: " + " " +
				                     model.Email + "\r\n" + "Telefonnummer: " + " " +
				                     CheckPhone(model.Phonenumber),
				              From = new MailAddress(model.Email),
			              };
			return message;

		}

		private static string CheckPhone(string phone)
		{
			return !string.IsNullOrWhiteSpace(phone) ? phone : string.Empty;
		}
	}
	
}