using Microsoft.AspNetCore.Identity;
namespace TaskManagement.Domain
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string Role { get; set; } = "User";
        public ICollection<TaskItem> Tasks { get; set; } = new List<TaskItem>();

        public ApplicationUser(string userName, string role)
        {
            UserName = userName;
            Role = role;
        }

        public ApplicationUser() { }
    }
}
