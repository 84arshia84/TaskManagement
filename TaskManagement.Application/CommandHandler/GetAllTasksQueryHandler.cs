using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Domain;
using TaskManagement.Persistence;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace TaskManagement.Application.Queries.GetAllTasks
{
    public class GetAllTasksQueryHandler : IRequestHandler<GetAllTasksQuery, List<TaskItem>>
    {
        private readonly DatabaseContext _context;

        public GetAllTasksQueryHandler(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<TaskItem>> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
        {
            var query = _context.Tasks.AsQueryable();

            if (request.Status.HasValue)
            {
                query = query.Where(t => t.Status == request.Status.Value);
            }

            return await query.ToListAsync(cancellationToken);
        }
    }
}