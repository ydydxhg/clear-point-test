using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoList.Api.Core.TodoItems.Command;
using TodoList.Api.Core.TodoItems.Queries.GetTodoItems;
using TodoList.Api.Shared.Entities;

namespace TodoList.Api.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ApiControllerBase
    {
        private readonly ILogger<TodoItemsController> _logger;

        public TodoItemsController(ILogger<TodoItemsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodoItems()
        {
            var request = new GetTodoItemsQuery();
            var result = await Mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> GetTodoItemById(Guid id)
        {
            var request = new GetTodoItemByGuidQuery
            {
                Id = id
            };
            var result = await Mediator.Send(request);
            return Ok(result);
        }

        [HttpPut()]
        public async Task<ActionResult<TodoItem>> CreateTodoItem([FromBody] TodoItem item)
        {
            var request = new CreateTodoItemCommand
            {
                Item = item
            };

            var result = await Mediator.Send(request);
            return Ok(result);
        }

        [HttpPost()]
        [Route("/api/completeItem")]
        public async Task<ActionResult<TodoItem>> CompleteTodoItem([FromBody] TodoItem item)
        {
            try
            {
                var request = new CompleteTodoItemCommand 
                {
                    Guid = item.Guid
                };
                var result = await Mediator.Send(request);
                return Ok(result);
            }
            catch (InvalidDataException)
            {
                _logger.LogError("Invalid Guid");
                //not found
                return NotFound();
            }
        }
    }
}
