using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Application.Command;
using TaskManagement.Domain;
using TaskManagement.Persistence;

namespace TaskManagement.Application.CommandHandler
{
    public class GetTasksByUserIdCommandHandler : IRequestHandler<GetTasksByUserIdCommand, List<TaskItem>>
    {
        private readonly DatabaseContext _context;

        public GetTasksByUserIdCommandHandler(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<TaskItem>> Handle(GetTasksByUserIdCommand request, CancellationToken cancellationToken)
        {
            return await _context.Tasks
                .Where(t => t.AssignedUserId == request.UserId)
                .ToListAsync(cancellationToken);
        }
    }
}