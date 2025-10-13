using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Models{
    public class ChatRoom{
        [Required]
        [Key]
        [Column(TypeName = "varchar(36)")]
        public string Id {get; set;}

        [Required]
        public List<string> Participants {get; set;}
    }
}