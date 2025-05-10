using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Domain;
using TaskManagement.Persistence;

namespace TaskManagement.Application.Queries.GetTaskById
{
    public class GetTaskByIdQueryHandler : IRequestHandler<GetTaskByIdQuery, TaskItem?>
    {
        private readonly DatabaseContext _context;

        public GetTaskByIdQueryHandler(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<TaskItem?> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
        {
            // استفاده از SingleOrDefaultAsync برای جستجوی دقیق تسک با id خاص
            return await _context.Tasks
                .Include(t => t.AssignedUser)
                .SingleOrDefaultAsync(t => t.Id == request.Id, cancellationToken);
        }
    }
}