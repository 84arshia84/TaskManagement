using MediatR;
using TaskManagement.Application.Commands.CreateTask;
using TaskManagement.Domain;
using TaskManagement.Domain.IRepositories;

namespace TaskManagement.Application.CommandHandler
{
    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, Guid>
    {

        private readonly ITaskItemRepository _taskItemRepository;

        public CreateTaskCommandHandler(ITaskItemRepository taskItemRepository)
        {
            _taskItemRepository = taskItemRepository;
        }


        public async Task<Guid> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var task = new TaskItem(request.Title, request.Description, request.AssignedUserId, request.Status);
            await _taskItemRepository.CreateAsync(task);
            return task.Id;
        }
    }
}