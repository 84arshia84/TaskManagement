using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Application.Query;
using TaskManagement.Domain;
using TaskManagement.Persistence;

namespace TaskManagement.Application.QueryHandler
{
    public class GetTasksByUserIdQuerydHandler : IRequestHandler<GetTasksByUserIdQuery, List<TaskItem>>
    {
        private readonly ITaskItemRepository _taskItemRepository;

        public GetTasksByUserIdQuerydHandler(ITaskItemRepository taskItemRepository)
        {
            _taskItemRepository = taskItemRepository;
        }

        public async Task<List<TaskItem>> Handle(GetTasksByUserIdQuery request, CancellationToken cancellationToken)
        {
            return await _taskItemRepository.GetByUserIdAsync(request.UserId);
        }
    }
}