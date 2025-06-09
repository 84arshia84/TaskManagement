using MediatR;

namespace TaskManagement.Application.Query
{
    public class GetTasksByStatusQuery : IRequest<List<TaskDto>>
    {
        public Domain.TaskStatus Status { get; set; }
    }

    public class TaskDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public Domain.TaskStatus Status { get; set; }
    }
}