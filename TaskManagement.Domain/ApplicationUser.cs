using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
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
