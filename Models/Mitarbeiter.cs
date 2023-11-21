using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace JetStreamBackend.Models
{
    public class Mitarbeiter
    {
        [Key]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("username")]
        public string Benutzername { get; set; }

        [JsonPropertyName("password")]
        public string Passwort { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("telephone")]
        public string Telefonnummer { get; set; }

        [JsonPropertyName("role")]
        public string Rolle { get; set; }

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }

        [JsonPropertyName("creationDate")]
        public DateTime Erstellungsdatum { get; set; }

        [JsonPropertyName("lastLogin")]
        public DateTime LetzteAnmeldung { get; set; }

        public int LoginVersuche { get; set; } = 0;
        public bool IstGesperrt { get; set; } = false;


    }
    public class LastLoginModel
    {
        [JsonPropertyName("lastLogin")]
        public DateTime LastLogin { get; set; }
    }


}
