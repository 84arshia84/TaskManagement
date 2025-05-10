using MediatR;
using System;

namespace TaskManagement.Application.Commands.UpdateTask
{
    public class UpdateTaskCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public TaskManagement.Domain.TaskStatus Status { get; set; }
        public Guid AssignedUserId { get; set; }
    }
}