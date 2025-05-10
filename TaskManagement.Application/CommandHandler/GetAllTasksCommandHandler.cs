using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Application.Command;
using TaskManagement.Application.Queries.GetAllTasks;
using TaskManagement.Domain;
using TaskManagement.Persistence;
using TaskStatus = TaskManagement.Domain.TaskStatus;

namespace TaskManagement.Application.Queries.GetTasksByUserId
{
    public class GetAllTasksCommandHandler : IRequestHandler<GetAllTasksCommand, List<TaskItem>>
    {

        private readonly ITaskItemRepository _taskItemRepository;

        public GetAllTasksCommandHandler(ITaskItemRepository taskItemRepository)
        {
            _taskItemRepository = taskItemRepository;
        }


        public async Task<List<TaskItem>> Handle(GetAllTasksCommand request, CancellationToken cancellationToken)
        {
           
            var result = await _taskItemRepository.GetByStatusAsync((int?)request.Status);
            return result;

        }
    }
}