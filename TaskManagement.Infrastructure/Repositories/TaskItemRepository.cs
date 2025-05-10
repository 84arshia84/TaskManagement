using Microsoft.EntityFrameworkCore;
using TaskManagement.Domain;
using TaskManagement.Persistence;

namespace TaskManagement.Infrastructure.Repositories
{
    public class TaskItemRepository : ITaskItemRepository
    {
        private readonly DatabaseContext _context;

        public TaskItemRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(TaskItem taskItem)
        {
            await _context.Tasks.AddAsync(taskItem);
            await _context.SaveChangesAsync();
        }

        public async Task<List<TaskItem>> GetAllAsync()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task<TaskItem?> GetByIdAsync(Guid id)
        {
            return await _context.Tasks.FirstOrDefaultAsync(item => item.Id == id);
        }

        public async Task<List<TaskItem>> GetByStatusAsync(int? status)
        {
            return await _context.Tasks
                .Where(item =>
                    status == null || (int)item.Status == status)
                .ToListAsync();
        }

        public async Task<List<TaskItem>> GetByUserIdAsync(Guid userId)
        {
            return await _context.Tasks
                .Where(item => item.AssignedUserId == userId)
                .ToListAsync();
        }

        public async Task<bool> UpdateAsync(TaskItem taskItem)
        {
            var existingTask = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == taskItem.Id);
            if (existingTask == null)
                return false;

            existingTask.UpdateTask(
                taskItem.Title,
                taskItem.Description,
                taskItem.AssignedUserId,
                taskItem.Status
            );

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var task = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == id);
            if (task == null)
                return false;

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}