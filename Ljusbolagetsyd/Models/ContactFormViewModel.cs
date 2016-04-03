using System.ComponentModel.DataAnnotations;

namespace Ljusbolagetsyd.Models
{
	public class ContactFormViewModel
	{
		[Required(ErrorMessage = " - Ange ett namn")]
		public string Name { get; set; }

		public string Phonenumber { get; set; }

		[Required(ErrorMessage = " - Fyll i en korrekt epost")]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		[Required(ErrorMessage = " - Du måste skriva ett meddelande")]
		[DataType(DataType.MultilineText)]
		public string MessageText { get; set; }

		public bool	Succes { get; set; }
	}
}