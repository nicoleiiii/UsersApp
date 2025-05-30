using Microsoft.AspNetCore.Identity;

namespace UsersApp.Models
{
	public class Users :IdentityUser
	{
		public string Fullname { get; set; }	
	}
}
