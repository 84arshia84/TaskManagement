using MediatR;
using System;
using System.Collections.Generic;
using TaskManagement.Domain;

namespace TaskManagement.Application.Command
{
    public class GetTasksByUserIdQuery : IRequest<List<TaskItem>>
    {
        public Guid UserId { get; }

        public GetTasksByUserIdQuery(Guid userId)
        {
            UserId = userId;
        }
    }
}