namespace TaskManagement.Domain
{
    public class TaskItem
    {
        public TaskItem(string title, string description, Guid assignedUserId)
        {
            Id = Guid.NewGuid();
            Title = title;
            Description = description;
            AssignedUserId = assignedUserId;
            Status = TaskStatus.Pending;
        }

        public TaskItem(string title, string description, Guid assignedUserId, TaskStatus status)
        {
            Id = Guid.NewGuid();
            Title = title;
            Description = description;
            AssignedUserId = assignedUserId;
            Status = status;
        }


        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public TaskStatus Status { get; private set; }
        public Guid AssignedUserId { get; private set; }

        public void UpdateTask(
            string title,
            string description,
            Guid assignedUserId,
            TaskStatus status)
        {
            Title = title;
            Description = description;
            Status = status;
            AssignedUserId = assignedUserId;
        }



    }

}
