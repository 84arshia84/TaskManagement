using MediatR;
using TaskManagement.Persistence;

namespace TaskManagement.Application.Commands.DeleteTask
{
    public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand, Unit>
    {
        private readonly DatabaseContext _context;

        public DeleteTaskCommandHandler(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            var task = await _context.Tasks.FindAsync(request.Id);
            if (task == null)
            {
                throw new KeyNotFoundException("Task not found");
            }

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}