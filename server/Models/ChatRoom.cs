using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace server.Models{
    public class ChatRoom{
        [Required]
        [Key]
        [Column(TypeName = "varchar(36)")]
        public string Id {get; set;}

        [NotMapped]
        public List<string> Participants { get; set; } = new List<string>();

        public string ParticipantsJson
        {
            get => JsonSerializer.Serialize(Participants);
            set => Participants = string.IsNullOrEmpty(value)
                ? new List<string>()
                : JsonSerializer.Deserialize<List<string>>(value) ?? new List<string>();
        }
    }
}