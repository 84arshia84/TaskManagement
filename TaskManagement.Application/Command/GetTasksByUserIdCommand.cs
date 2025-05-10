using MediatR;
using System;
using System.Collections.Generic;
using TaskManagement.Domain;

namespace TaskManagement.Application.Command
{
    public class GetTasksByUserIdCommand : IRequest<List<TaskItem>>
    {
        public Guid UserId { get; }

        public GetTasksByUserIdCommand(Guid userId)
        {
            UserId = userId;
        }
    }
}