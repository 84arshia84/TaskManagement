using MediatR;
using TaskManagement.Domain;
using TaskManagement.Persistence;

namespace TaskManagement.Application.Commands.CreateTask
{
    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, Guid>
    {
        private readonly DatabaseContext _context;

        public CreateTaskCommandHandler(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var task = new TaskItem
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                Description = request.Description,
                Status = request.Status,
                AssignedUserId = request.AssignedUserId
            };

            _context.Tasks.Add(task);
            await _context.SaveChangesAsync(cancellationToken);

            return task.Id;
        }
    }
}