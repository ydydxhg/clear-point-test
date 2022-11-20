using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Api.Core.Interfaces;
using TodoList.Api.Shared.Entities;

namespace TodoList.Api.Infrastructure.Repositories
{
    public class TodoItemsRepository : ITodoItemsRepository
    {
        private TodoContext _context;
        public TodoItemsRepository(TodoContext context)
        {
            _context = context; 
        }

        public async Task<TodoItem> GetItem(Guid guid)
        {
            return _context.TodoItems.SingleOrDefault(r => r.Guid == guid);
        }

        public async Task<IEnumerable<TodoItem>> GetItems(bool isCompleted)
        {
            return _context.TodoItems.Where(r=> r.IsCompleted == isCompleted).ToList();
        }

        public async Task<TodoItem> CreateItem(TodoItem item)
        {
            //always create a new guid
            var newItem = new TodoItem
            {
                Guid = Guid.NewGuid(),
                Description = item.Description,
                IsCompleted = false,
            };
            await _context.TodoItems.AddAsync(newItem);
            await _context.SaveChangesAsync();
            return newItem;
        }

        public async Task<bool> CompleteItem(Guid guid)
        {
            var item = _context.TodoItems.SingleOrDefault(r=> r.Guid == guid);
            if(item == null)
            {
                throw new InvalidDataException();
            }
            item.IsCompleted = true;
            item.ModifiedOn = DateTime.Now;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
