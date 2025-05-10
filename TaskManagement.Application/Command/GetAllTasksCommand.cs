using MediatR;
using System;
using System.Collections.Generic;
using TaskManagement.Domain;

namespace TaskManagement.Application.Queries.GetAllTasks
{
    public class GetAllTasksCommand : IRequest<List<TaskItem>>
    {
        public TaskManagement.Domain.TaskStatus? Status { get; set; }

    }
}