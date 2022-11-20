using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Api.Core.Interfaces;
using TodoList.Api.Shared.Entities;

namespace TodoList.Api.Core.TodoItems.Command
{
    public class CreateTodoItemCommand :IRequest<TodoItem>
    {
        public TodoItem Item { get; set; }
    }
    public class CreateTodoItemCommandHandler : IRequestHandler<CreateTodoItemCommand, TodoItem>
    {
        private readonly ITodoItemsRepository _repository;
        public CreateTodoItemCommandHandler(ITodoItemsRepository todoItemsRepository)
        {
            _repository = todoItemsRepository;
        }
        public async Task<TodoItem> Handle(CreateTodoItemCommand request, CancellationToken cancellationToken)
        {
            var result = await _repository.CreateItem(request.Item);
            return result;
        }
    }
}
