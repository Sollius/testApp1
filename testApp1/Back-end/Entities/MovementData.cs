using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace testApp1.Back_end.Entities
{
    public class MovementData
    {
        public int Id { get; set; }

        public Guid SessionId { get; set; } = Guid.NewGuid();

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column(TypeName = "NVARCHAR(MAX)")]
        public string TrackingDataJson { get; set; } = string.Empty;

        [NotMapped]
        public List<MousePoint> TrackingData
        {
            get => JsonSerializer.Deserialize<List<MousePoint>>(TrackingDataJson)!;
            set => TrackingDataJson = JsonSerializer.Serialize<List<MousePoint>>(value);
        }
    }
}
