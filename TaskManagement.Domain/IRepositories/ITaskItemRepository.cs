using TaskManagement.Domain;

public interface ITaskItemRepository
{
    Task CreateAsync(TaskItem taskItem);
    Task<List<TaskItem>> GetAllAsync();
    Task<TaskItem?> GetByIdAsync(Guid id);
    Task<List<TaskItem>> GetByStatusAsync(int? status);
    Task<List<TaskItem>> GetByUserIdAsync(Guid userId);
    Task<bool> UpdateAsync(TaskItem taskItem);
    Task<bool> DeleteAsync(Guid id);
}