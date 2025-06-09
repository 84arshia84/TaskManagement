using MediatR;
using System;
using System.Collections.Generic;
using TaskManagement.Domain;

namespace TaskManagement.Application.Query
{
    public class GetAllTasksQuery : IRequest<List<TaskItem>>
    {
        public Domain.TaskStatus? Status { get; set; }

    }
}