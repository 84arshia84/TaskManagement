using MediatR;

namespace TaskManagement.Application.Command
{
    public class GetTasksByStatusCommand : IRequest<List<TaskDto>>
    {
        public Domain.TaskStatus Status { get; set; }
    }

    public class TaskDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public TaskManagement.Domain.TaskStatus Status { get; set; }
    }
}