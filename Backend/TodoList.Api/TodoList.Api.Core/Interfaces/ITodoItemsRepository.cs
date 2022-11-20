using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Api.Shared.Entities;

namespace TodoList.Api.Core.Interfaces
{
    public interface ITodoItemsRepository
    {
        Task<IEnumerable<TodoItem>> GetItems(bool isCompleted);
        Task<TodoItem> GetItem(Guid guid);
        Task<TodoItem> CreateItem(TodoItem item);
        Task<bool> CompleteItem(Guid guid);
    }
}
