using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoList.Api.Shared.Entities
{
    public class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Guid { get; set; }
        /// <summary>
        /// User who created the item
        /// </summary>
        public int CreatedBy { get; set; }
        /// <summary>
        /// time created
        /// </summary>
        [Column(TypeName = "timestamp")]
        public DateTime CreatedOn { get; set; }
        /// <summary>
        /// User who modified
        /// </summary>
        public int? ModifiedBy { get; set; }
        /// <summary>
        /// time modified
        /// </summary>
        [Column(TypeName = "timestamp")]
        public DateTime? ModifiedOn { get; set; }
        public BaseEntity()
        {
            CreatedOn = DateTime.Now;
        }
    }
}
