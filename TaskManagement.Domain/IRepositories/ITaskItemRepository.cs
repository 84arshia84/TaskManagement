namespace TaskManagement.Domain.IRepositories;

public interface ITaskItemRepository
{
    Task CreateAsync(TaskItem taskItem);

    Task<List<TaskItem>> GetAllAsync();

    Task<TaskItem> GetByIdAsync(Guid id);

    Task<List<TaskItem>> GetByStatusAsync(int? status);
}
