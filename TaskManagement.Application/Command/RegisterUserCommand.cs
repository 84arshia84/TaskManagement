using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Application.Command
{
    public class RegisterUserCommand : IRequest<RegisterUserResult>
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Role { get; set; } = "User"; // "Admin" or "User"
    }

    public class RegisterUserResult
    {
        public bool Success { get; set; }
        public IEnumerable<string>? Errors { get; set; }
    }
}
