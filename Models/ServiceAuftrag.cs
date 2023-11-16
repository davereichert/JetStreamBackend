using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace JetStreamBackend.Models
{
    public class ServiceAuftrag
    {
        [Key]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string KundenName { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("priority")]
        public string Priority { get; set; }

        [JsonPropertyName("service")]
        public string Service { get; set; }


        [JsonPropertyName("create_date")]
        [JsonConverter(typeof(JsonDateTimeConverter))]
        public DateTime SendDate { get; set; }

        [JsonPropertyName("pickup_date")]
        [JsonConverter(typeof(JsonDateTimeConverter))]
        public DateTime PickupDate { get; set; }


    }

}
