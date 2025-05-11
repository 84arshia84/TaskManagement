using MediatR;
using TaskManagement.Persistence;

namespace TaskManagement.Application.Commands.DeleteTask
{
    public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand, Unit>
    {
        private readonly ITaskItemRepository _taskItemRepository;

        public DeleteTaskCommandHandler(ITaskItemRepository taskItemRepository)
        {
            _taskItemRepository = taskItemRepository;
        }

        public async Task<Unit> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            var task = await _taskItemRepository.GetByIdAsync(request.Id);
         
            var result = await _taskItemRepository.DeleteAsync(task);

            return Unit.Value;
        }
    }
}