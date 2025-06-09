using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Persistence;
using TaskManagement.Application.Query;

namespace TaskManagement.Application.QueryHandler
{
    public class GetTasksByStatusQuerydHandler : IRequestHandler<GetTasksByStatusQuery, List<TaskDto>>
    {
        private readonly ITaskItemRepository _taskItemRepository;

        public GetTasksByStatusQuerydHandler(ITaskItemRepository taskItemRepository)
        {
            _taskItemRepository = taskItemRepository;
        }
        public async Task<List<TaskDto>> Handle(GetTasksByStatusQuery request, CancellationToken cancellationToken)
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
