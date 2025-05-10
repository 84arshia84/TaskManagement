using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Application.Command;
using TaskManagement.Application.Queries.GetAllTasks;
using TaskManagement.Domain;
using TaskManagement.Persistence;
using TaskStatus = TaskManagement.Domain.TaskStatus;

namespace TaskManagement.Application.Queries.GetTasksByUserId
{
    public class GetTasksByUserIdQueryHandler : IRequestHandler<GetAllTasksQuery, List<TaskItem>>
    {
        private readonly DatabaseContext _context;

        public GetTasksByUserIdQueryHandler(DatabaseContext context)
        {
            _context = context;
        }



        public async Task<List<TaskItem>> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
        {
            var AllTask = await _context.Tasks.ToListAsync();
            if (request.Status== TaskStatus.Pending)
            {
                AllTask =  AllTask.Where(a => a.Status == 0).ToList();
            }
            if (request.Status == TaskStatus.InProgress)
            {
                AllTask = AllTask.Where(a => a.Status == TaskStatus.InProgress).ToList();
            }
            if (request.Status == TaskStatus.Completed)
            {
                AllTask = AllTask.Where(a => a.Status == TaskStatus.Completed).ToList();
            }

            return AllTask;

        }
    }
}