using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Application.Command
{
    public class UpdateUserTaskCommand : IRequest<bool>

    {
        public Guid Id { get; set; }
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public TaskManagement.Domain.TaskStatus Status { get; set; }
    }
}
