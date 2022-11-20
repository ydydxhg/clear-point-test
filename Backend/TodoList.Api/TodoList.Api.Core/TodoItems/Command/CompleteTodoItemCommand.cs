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
    public  class CompleteTodoItemCommand :IRequest<bool>
    {
        public Guid Guid { get; set; }
    }
    public class CompleteTodoItemCommandHandler : IRequestHandler<CompleteTodoItemCommand, bool>
    {
        private readonly ITodoItemsRepository _repository;
        public CompleteTodoItemCommandHandler(ITodoItemsRepository todoItemsRepository)
        {
            _repository = todoItemsRepository;
        }
        public async Task<bool> Handle(CompleteTodoItemCommand request, CancellationToken cancellationToken)
        {
            var result = await _repository.CompleteItem(request.Guid);
            return result;
        }
    }
}
