using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Domain
{
    public class TaskItem
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public TaskStatus Status { get; set; } = TaskStatus.Pending;
        public Guid AssignedUserId { get; set; }
        public ApplicationUser? AssignedUser { get; set; }



        public TaskItem(string title, string description, TaskStatus status, Guid assignedUserId)
        {
            Id = Guid.NewGuid();
            Title = title;
            Description = description;
            Status = status;
            AssignedUserId = assignedUserId;
        }
    }

}
