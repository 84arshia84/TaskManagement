using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Application.Command;
using TaskManagement.Persistence;

namespace TaskManagement.Application.CommandHandler
{
    public class GetTasksByStatusQueryHandler : IRequestHandler<GetTasksByStatusQuery, List<TaskDto>>
    {
        private readonly DatabaseContext _context;

        public GetTasksByStatusQueryHandler(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<TaskDto>> Handle(GetTasksByStatusQuery request, CancellationToken cancellationToken)
        {
            return await _context.Tasks
                .Where(t => t.Status == request.Status)
                .Select(t => new TaskDto
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    Status = t.Status
                })
                .ToListAsync(cancellationToken);
        }
    }
}
