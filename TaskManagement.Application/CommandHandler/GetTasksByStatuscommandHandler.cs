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
    public class GetTasksByStatusCommandHandler : IRequestHandler<GetTasksByStatusCommand, List<TaskDto>>
    {
        private readonly ITaskItemRepository _taskItemRepository;

        public GetTasksByStatusCommandHandler(ITaskItemRepository taskItemRepository)
        {
            _taskItemRepository = taskItemRepository;
        }
        public async Task<List<TaskDto>> Handle(GetTasksByStatusCommand request, CancellationToken cancellationToken)
        {
            var tasks = await _taskItemRepository.GetByStatusAsync((int?)request.Status);

            return tasks.Select(t => new TaskDto
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                Status = t.Status
            }).ToList();
        }
    }
}
