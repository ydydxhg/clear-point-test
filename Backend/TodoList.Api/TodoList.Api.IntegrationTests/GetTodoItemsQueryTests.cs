using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Api.Core.Tests.Mocks;
using TodoList.Api.Core.TodoItems.Queries.GetTodoItems;
using Xunit;

namespace TodoList.Api.Core.Tests
{
    public  class GetTodoItemsQueryTests : BaseTests
    {
        public GetTodoItemsQueryTests() : base()
        {
        }

        [Fact]
        public async Task GetItems_Should_Return_Correct_Items()
        {
            //empty the list before testing
            _repository.Items.Clear();

            var request = new GetTodoItemsQuery();
            var handler = new GetTodoItemsQueryHandler(_repository);
            var result = await handler.Handle(request, new System.Threading.CancellationToken());
            Assert.NotNull(result);
            Assert.Empty(result);

            AddNewItem();
            result = await handler.Handle(request, new System.Threading.CancellationToken());
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);

            //should only return incompleted items
            _repository.Items.First().IsCompleted = true;
            result = await handler.Handle(request, new System.Threading.CancellationToken());
            Assert.NotNull(result);
            Assert.Empty(result);
        }

    }
}
