using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Api.Core.Interfaces;
using TodoList.Api.Shared.Entities;

namespace TodoList.Api.Core.TodoItems.Queries.GetTodoItems
{
    public class GetTodoItemsQuery : IRequest<IEnumerable<TodoItem>>
    {
    }
    public class GetTodoItemsQueryHandler : IRequestHandler<GetTodoItemsQuery, IEnumerable<TodoItem>>
    {
        private readonly ITodoItemsRepository _repository;

        public GetTodoItemsQueryHandler(ITodoItemsRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<TodoItem>> Handle(GetTodoItemsQuery request, CancellationToken cancellationToken)
        {
            var items = await _repository.GetItems(false);
            return items;
        }
    }
}
