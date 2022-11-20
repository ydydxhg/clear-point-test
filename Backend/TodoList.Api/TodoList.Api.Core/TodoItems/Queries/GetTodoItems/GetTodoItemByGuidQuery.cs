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
    public class GetTodoItemByGuidQuery : IRequest<TodoItem>
    {
        public Guid Id { get; set; }
    }
    public class GetTodoItemByGuidQueryHandler : IRequestHandler<GetTodoItemByGuidQuery, TodoItem>
    {
        private readonly ITodoItemsRepository _repository;

        public GetTodoItemByGuidQueryHandler(ITodoItemsRepository repository)
        {
            _repository = repository;
        }
        public async Task<TodoItem>? Handle(GetTodoItemByGuidQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetItem(request.Id);
        }
    }
}
