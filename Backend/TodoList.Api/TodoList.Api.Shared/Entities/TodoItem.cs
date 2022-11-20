using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Api.Shared.Entities
{
    public class TodoItem : BaseEntity
    {
        /// <summary>
        /// Todo Item
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Indicate if the todo item is completed
        /// </summary>
        public bool IsCompleted { get; set; }
    }
}
