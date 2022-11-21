using System;
using TodoList.Api.Shared.Entities;
using Xunit;

namespace TodoList.Api.Shared.UnitTests
{
    public class TodoItemTests
    {
        [Fact]
        public void New_TodoItem_Should_UseCurrentDate()
        {
            var today = DateTime.Now;
            var todoItem = new TodoItem();

            Assert.Equal(today.Year, todoItem.CreatedOn.Year);
            Assert.Equal(today.Month, todoItem.CreatedOn.Month);
            Assert.Equal(today.Day, todoItem.CreatedOn.Day);
        }
    }
}