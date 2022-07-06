using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Models
{
    public class ToDoCategory
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; } = DateTime.Now;
        public string IsDeleted { get; set; }
        public string IsCompleted { get; set; }
    }
}
