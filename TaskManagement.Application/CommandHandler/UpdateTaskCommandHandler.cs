using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Domain;
using TaskManagement.Persistence;

namespace TaskManagement.Application.Commands.UpdateTask
{
    public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand, bool>
    {
        private readonly DatabaseContext _context;

        public UpdateTaskCommandHandler(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            var task = await _context.Tasks.FindAsync(new object[] { request.Id }, cancellationToken);
            if (task == null)
                return false;

            task.Title = request.Title;
            task.Description = request.Description;
            task.Status = request.Status;
            task.AssignedUserId = request.AssignedUserId;

            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}