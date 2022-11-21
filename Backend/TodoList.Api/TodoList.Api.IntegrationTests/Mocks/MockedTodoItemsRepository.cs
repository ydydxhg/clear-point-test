using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Api.Core.Interfaces;
using TodoList.Api.Shared.Entities;

namespace TodoList.Api.Core.Tests.Mocks
{
    public class MockedTodoItemsRepository : ITodoItemsRepository
    {
        public List<TodoItem> Items { get; set; }

        public MockedTodoItemsRepository()
        {
            Items = new List<TodoItem>();
        }
        public async Task<bool> CompleteItem(Guid guid)
        {
            var item = Items.SingleOrDefault(r=> r.Guid == guid); 
            if (item != null)
            {
                item.IsCompleted = true;
                return true;
            }
            return false;
        }

        public async Task<TodoItem> CreateItem(TodoItem item)
        {
            item.Guid = Guid.NewGuid();
            Items.Add(item);
            return item;
        }

        public async Task<TodoItem> GetItem(Guid guid)
        {
            var item = Items.SingleOrDefault(r => r.Guid == guid);
            return item;
        }

        public async Task<IEnumerable<TodoItem>> GetItems(bool isCompleted)
        {
            var items = Items.Where(r => !r.IsCompleted);
            return items.ToList();
        }
    }
}
