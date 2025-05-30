namespace UsersApp.Models
{
    public class AppDbHosting
    {
        public int Id { get; set; }
        public required string FullName { get; set; }

        public required string Email { get; set; }

        public required string Password { get; set; }
    }
}
