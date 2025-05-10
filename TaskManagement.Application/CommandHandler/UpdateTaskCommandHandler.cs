using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Domain;
using TaskManagement.Persistence;

namespace TaskManagement.Application.Commands.UpdateTask
{
    public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand, bool>
    {
        private readonly ITaskItemRepository _taskItemRepository;

        public UpdateTaskCommandHandler(ITaskItemRepository taskItemRepository)
        {
            _taskItemRepository = taskItemRepository;
        }

        public async Task<bool> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            var existingTask = await _taskItemRepository.GetByIdAsync(request.Id);
            if (existingTask == null)
                return false;

            existingTask.UpdateTask(
                title: request.Title,
                description: request.Description,
                assignedUserId: request.AssignedUserId,
                status: request.Status
            );

            return await _taskItemRepository.UpdateAsync(existingTask);
        }
    }
}