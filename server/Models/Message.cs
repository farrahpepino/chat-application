using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Models{

    public class Message{
        [Required]
        [Column(TypeName = "varchar(36)")]
        public string Id {get; set;} = Guid.NewGuid().ToString();

        [Required]
        [Column(TypeName = "varchar(36)")]
        public string ChatRoomId {get; set;}

        [Required]
        [Column(TypeName = "varchar(36)")]
        public string SenderId {get; set;}

        [Required]
        public string Content {get; set;}

        [Required]
        public DateTime CreatedAt {get; set;} = DateTime.Now;
    }
}