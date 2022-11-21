using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Api.Core.Tests.Mocks;

namespace TodoList.Api.Core.Tests
{
    public class BaseTests
    {
        protected MockedTodoItemsRepository _repository;
        public BaseTests()
        {
            _repository = new MockedTodoItemsRepository();
        }

        protected void AddNewItem()
        {
            _repository.Items.Add(new Shared.Entities.TodoItem
            {
                Description = "test",
            });
        }
    }
}
