using MediatR;
using System;
using TaskManagement.Domain;

namespace TaskManagement.Application.Queries.GetTaskById
{
    public class GetTaskByIdQuery : IRequest<TaskItem?> // درخواست برای تسک خاص با شناسه GUID
    {
        public Guid Id { get; set; }

        public GetTaskByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}