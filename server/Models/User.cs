using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Models{
    
    public class User
    {
        [Required]
        [Key]
        [Column(TypeName = "varchar(36)")]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [MaxLength(50)]
        public required string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public required string Username { get; set; }
        
        [Required]
        [MaxLength(254)]
        public required string Email { get; set; }

        [Required]
        [MaxLength(1000)]
        public required string Password { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}