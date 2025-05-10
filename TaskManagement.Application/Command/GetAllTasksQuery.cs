using MediatR;
using System;
using System.Collections.Generic;
using TaskManagement.Domain;

namespace TaskManagement.Application.Queries.GetAllTasks
{
    public class GetAllTasksQuery : IRequest<List<TaskItem>>
    {
        public TaskManagement.Domain.TaskStatus? Status { get; set; }

        public GetAllTasksQuery(TaskManagement.Domain.TaskStatus? status = null)
        {
            Status = status;
        }
    }
}