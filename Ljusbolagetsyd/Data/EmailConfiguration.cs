using System.Configuration;

namespace Ljusbolagetsyd.Data
{
	public class EmailConfiguration
	{
		public string Host { get; set; }
		public int Port { get; set; }
		public string To { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }

		public EmailConfiguration FetchConfigurationForMail()
		{
			return new EmailConfiguration
									 {
										 Host = ConfigurationManager.AppSettings["MailHost"],
										 Port = int.Parse(ConfigurationManager.AppSettings["MailPort"]),
										 To = ConfigurationManager.AppSettings["EmailAddress"],
										 Email = ConfigurationManager.AppSettings["EmailAddress"],
										 Password = ConfigurationManager.AppSettings["EmailPassword"]
									 };
		}
	}
}