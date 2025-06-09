using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Application.Command;
using TaskManagement.Application.Query;
using TaskManagement.Domain;
using TaskManagement.Persistence;
using TaskStatus = TaskManagement.Domain.TaskStatus;

namespace TaskManagement.Application.QueryHandler
{
    public class GetAllTasksQueryHandler : IRequestHandler<GetAllTasksQuery, List<TaskItem>>
    {

        private readonly ITaskItemRepository _taskItemRepository;

        public GetAllTasksQueryHandler(ITaskItemRepository taskItemRepository)
        {
            _taskItemRepository = taskItemRepository;
        }


        public async Task<List<TaskItem>> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
        {

            var result = await _taskItemRepository.GetByStatusAsync((int?)request.Status);
            return result;

        }
    }
}