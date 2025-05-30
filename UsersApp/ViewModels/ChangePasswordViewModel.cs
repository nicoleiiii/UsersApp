using System.ComponentModel.DataAnnotations;

namespace UsersApp.ViewModels
{
	public class ChangePasswordViewModel
	{
		[Required(ErrorMessage = "Email is required.")]
		[EmailAddress]
		public required string Email { get; set; }

		[Required(ErrorMessage = "Password is required.")]
		[StringLength(100, MinimumLength = 8, ErrorMessage = "The {0} must be at {2} and at max {1} characters long.")]
		[DataType(DataType.Password)]
		[Display(Name ="New Password")]
		
		public string NewPassword { get; set; }

		[Required(ErrorMessage = "Password is required.")]
		[DataType(DataType.Password)]
		[Display(Name = "Confirm New Password")]
		[Compare("ConfirmNewPassword", ErrorMessage = "Password does not match")]
		public string ConfirmNewPassword { get; set; }
	}
}
