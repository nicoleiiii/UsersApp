using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UsersApp.Models;

namespace UsersApp.Data
{
	public class AppDbContext : IdentityDbContext<Users>
	{
		public AppDbContext(DbContextOptions options) : base(options)
		{
		}

        public DbSet<Users> users { get; set; }
	    public DbSet<UsersApp.Models.AppDbHosting> AppDbHosting { get; set; } = default!;
	}
}
