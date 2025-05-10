using MediatR;
using TaskManagement.Domain;
namespace TaskManagement.Application.Commands.CreateTask
{
    public class CreateTaskCommand : IRequest<Guid>
    {
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public TaskManagement.Domain.TaskStatus Status { get; set; } = TaskManagement.Domain.TaskStatus.Pending;
        public Guid AssignedUserId { get; set; }
    }
}