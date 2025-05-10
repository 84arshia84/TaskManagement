using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Application.Command;
using TaskManagement.Domain;
using TaskManagement.Persistence;

namespace TaskManagement.Application.CommandHandler
{
    public class GetTasksByUserIdCommandHandler : IRequestHandler<GetTasksByUserIdCommand, List<TaskItem>>
    {
        private readonly ITaskItemRepository _taskItemRepository;

        public GetTasksByUserIdCommandHandler(ITaskItemRepository taskItemRepository)
        {
            _taskItemRepository = taskItemRepository;
        }

        public async Task<List<TaskItem>> Handle(GetTasksByUserIdCommand request, CancellationToken cancellationToken)
        {
            return await _taskItemRepository.GetByUserIdAsync(request.UserId);
        }
    }
}