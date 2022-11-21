using System.Threading.Tasks;
using TodoList.Api.Core.Tests;
using TodoList.Api.Core.Tests.Mocks;
using TodoList.Api.Core.TodoItems.Command;
using TodoList.Api.Shared.Entities;
using Xunit;

namespace TodoList.Api.IntegrationTests
{
    public class CreateTodoItemCommandTests : BaseTests
    {
        public CreateTodoItemCommandTests() : base()
        {
        }

        [Fact]
        public async Task CreateTodoItem_Should_AddToList()
        {
            var item = new TodoItem
            {
                Description = "Test",
                Guid = System.Guid.Empty//0000-0000....
            };

            var command = new CreateTodoItemCommand
            {
                Item = item,
            };

            var handler = new CreateTodoItemCommandHandler(_repository);
            var result = await handler.Handle(command, new System.Threading.CancellationToken());

            Assert.NotEqual(result.Guid, System.Guid.Empty);
            Assert.NotEmpty(_repository.Items);
            Assert.Equal(_repository.Items[_repository.Items.Count - 1].Guid, result.Guid);
            Assert.Equal(_repository.Items[_repository.Items.Count - 1].Description, result.Description);
        }
    }
}