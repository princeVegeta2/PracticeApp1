using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practice1.Services.EntityFramework.Entities
{
    public class Like
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public required User User { get; set; }

        public int PostId { get; set; }

        public required Posts Post { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
