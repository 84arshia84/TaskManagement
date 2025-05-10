using Microsoft.EntityFrameworkCore;
using TaskManagement.Domain;
using TaskManagement.Domain.IRepositories;
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
            var result = await _context.Tasks.ToListAsync();
            return result;
        }

        public async Task<TaskItem?> GetByIdAsync(Guid id)
        {
            var result = await _context.Tasks.FirstOrDefaultAsync(item => item.Id == id);
            return result;
        }

        public async Task<List<TaskItem>> GetByStatusAsync(int? status)
        {
            var result = await _context.Tasks
                .Where(item => 
                    (status == null) ||
                    (status != null && (int)item.Status == status))
                .ToListAsync();
            return result;
        }
    }
}
