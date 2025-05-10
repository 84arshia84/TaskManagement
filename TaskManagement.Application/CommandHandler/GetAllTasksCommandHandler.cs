using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Application.Command;
using TaskManagement.Application.Queries.GetAllTasks;
using TaskManagement.Domain;
using TaskManagement.Domain.IRepositories;
using TaskManagement.Persistence;
using TaskStatus = TaskManagement.Domain.TaskStatus;

namespace TaskManagement.Application.Queries.GetTasksByUserId
{
    public class GetAllTasksCommandHandler : IRequestHandler<GetAllTasksCommand, List<TaskItem>>
    {
        //private readonly DatabaseContext _context;

        //public GetAllTasksCommandHandler(DatabaseContext context)
        //{
        //    _context = context;
        //}
        private readonly ITaskItemRepository _taskItemRepository;

        public GetAllTasksCommandHandler(ITaskItemRepository taskItemRepository)
        {
            _taskItemRepository = taskItemRepository;
        }


        public async Task<List<TaskItem>> Handle(GetAllTasksCommand request, CancellationToken cancellationToken)
        {
            //var AllTask = await _context.Tasks.ToListAsync();
            //if (request.Status== TaskStatus.Pending)
            //{
            //    AllTask =  AllTask.Where(a => a.Status == 0).ToList();
            //}
            //if (request.Status == TaskStatus.InProgress)
            //{
            //    AllTask = AllTask.Where(a => a.Status == TaskStatus.InProgress).ToList();
            //}
            //if (request.Status == TaskStatus.Completed)
            //{
            //    AllTask = AllTask.Where(a => a.Status == TaskStatus.Completed).ToList();
            //}
            var result = await _taskItemRepository.GetByStatusAsync((int?)request.Status);
            return result;

        }
    }
}