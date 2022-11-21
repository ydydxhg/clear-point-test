using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Api.Core.Tests.Mocks;
using TodoList.Api.Core.TodoItems.Command;
using Xunit;

namespace TodoList.Api.Core.Tests
{
    public class CompleteTodoItemCommandTests : BaseTests
    {
        public CompleteTodoItemCommandTests(): base()
        {
        }

        [Fact]
        public async Task CompletedItem_IsComplete_Should_Be_True()
        {
            //empty the list before testing
            _repository.Items.Clear();
            AddNewItem();

            var command = new CompleteTodoItemCommand
            {
                Guid = _repository.Items.First().Guid,
            };

            var handler = new CompleteTodoItemCommandHandler(_repository);
            var result = await handler.Handle(command, new System.Threading.CancellationToken());
            
            Assert.True(result);

            var item = _repository.Items.First();
            Assert.True(item.IsCompleted);
        }

        [Fact]
        public async Task CompletedItem_Should_Not_Return()
        {
            //empty the list before testing
            _repository.Items.Clear();
            AddNewItem();

            var command = new CompleteTodoItemCommand
            {
                Guid = _repository.Items.First().Guid,
            };

            var handler = new CompleteTodoItemCommandHandler(_repository);
            var result = await handler.Handle(command, new System.Threading.CancellationToken());

            var items = await _repository.GetItems(false);
            Assert.Empty(items);
        }
    }
}
