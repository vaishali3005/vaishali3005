using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Razor.TagHelpers;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ToDoApp.Models
{
    public class ToDoCategory
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; } = DateTime.Now;
        public string IsDeleted { get; set; }
        public string IsCompleted { get; set; }

    }
}
