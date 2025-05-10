using MediatR;
using System;

namespace TaskManagement.Application.Commands.DeleteTask
{
    public class DeleteTaskCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }

        public DeleteTaskCommand(Guid id)
        {
            Id = id;
        }
    }
}