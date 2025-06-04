using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practice1.Services.EntityFramework.Entities
{
    public class Like
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public required User User { get; set; } = default!;
        [Required]
        public int PostId { get; set; }
        [ForeignKey(nameof(PostId))]
        public required Posts Post { get; set; } = default!;
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [Required]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
