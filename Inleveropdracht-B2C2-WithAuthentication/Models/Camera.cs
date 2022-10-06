

using System.ComponentModel.DataAnnotations;

namespace Inleveropdracht_B2C2_WithAuthentication.Models
{
    public class Camera
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Gebruiker { get; set; }
        [Required]
        public string Soort  { get; set; }
        [Required]
        public string Plaats { get; set; }
        [Required]
        public string Omschrijving { get; set; }

        public string? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
        

    }
}
