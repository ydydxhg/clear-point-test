using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Api.Core.TodoItems.Queries.GetTodoItems;
using Xunit;

namespace TodoList.Api.Core.Tests
{
    public class GetTodoItemByGuidQueryTests : BaseTests
    {
        public GetTodoItemByGuidQueryTests():base()
        {

        }

        [Fact]
        public async Task GetItemById_Should_Return_Correct_Item()
        {
            //empty the list before testing
            _repository.Items.Clear();

            var request = new GetTodoItemByGuidQuery
            {
                Id = Guid.NewGuid(),
            };

            var handler = new GetTodoItemByGuidQueryHandler(_repository);

            var result = await handler.Handle(request, new System.Threading.CancellationToken());
            Assert.Null(result);

            AddNewItem();
            result = await handler.Handle(request, new System.Threading.CancellationToken());
            //supplying the wrong id should still give you nothing
            Assert.Null(result);

            request.Id = _repository.Items.First().Guid;

            result = await handler.Handle(request, new System.Threading.CancellationToken());
            Assert.NotNull(result);
        }
    }
}
