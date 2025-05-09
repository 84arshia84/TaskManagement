using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain;

namespace TaskManagement.Persistence
{
    public class DatabaseContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // ارتباط بین تسک و کاربر تخصیص داده شده
            builder.Entity<TaskItem>()
                .HasOne(t => t.AssignedUser)
                .WithMany(u => u.Tasks)
                .HasForeignKey(t => t.AssignedUserId)
                .OnDelete(DeleteBehavior.Restrict); // جلوگیری از حذف کاربر در صورت داشتن تسک

            // لود تمام Configuration ها (اگه از Fluent API استفاده کنی)
            builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }

        public DbSet<TaskItem> Tasks { get; set; }  
    }
}

