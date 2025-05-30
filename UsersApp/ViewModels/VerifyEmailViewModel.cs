using System.ComponentModel.DataAnnotations;

namespace UsersApp.ViewModels
{
	public class VerifyEmailViewModel
	{
		[Required(ErrorMessage = "Email is required.")]
		[EmailAddress]
		public required string Email { get; set; }
	}
}
