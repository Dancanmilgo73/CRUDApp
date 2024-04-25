using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Todo
    {
        public Guid Id { get; set; }
        [Required] 
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public long? Factorial { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
    }
}
