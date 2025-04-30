using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;

namespace Practice1.Services.EntityFramework.Entities
{
    [Table("users")]
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public required string Username { get; set; }

        [Required]
        [MaxLength(50)]
        public required string Email { get; set; }

        [Required]
        public required string PasswordHash { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Referencing Posts
        public ICollection<Posts> Posts { get; set; } = new List<Posts>();

        // Referencing Friends
        public ICollection<Friendship> Friends { get; set; } = new List<Friendship>();

        public ICollection<Friendship> FriendOf { get; set; } = new List<Friendship>();

        public ICollection<Like> Likes { get; set; } = new List<Like>();

        public VerifiedUser? VerifiedUser { get; set; } = null;

    }
}
