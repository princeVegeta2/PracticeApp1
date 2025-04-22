using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practice1.Services.EntityFramework.Entities
{
    [Table("posts")]
    public class Posts
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; } = default!;

        [Required]
        [MaxLength(20)]
        public required string Type { get; set; }

        public int TotalLikes { get; set; } = 0;

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Required]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<Like> Likes { get; set; } = new List<Like>();
    }
}
