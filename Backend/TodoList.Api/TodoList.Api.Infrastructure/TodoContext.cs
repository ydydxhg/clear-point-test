using Microsoft.EntityFrameworkCore;
using TodoList.Api.Shared.Entities;

namespace TodoList.Api.Infrastructure
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; }
    }
}