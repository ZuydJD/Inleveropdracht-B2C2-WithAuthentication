

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inleveropdracht_B2C2_WithAuthentication.Models
{
    public class Camera
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Naam { get; set; }
        [Required]
        public string Soort  { get; set; }
        [Required]
        public string Plaats { get; set; }
        [Required]
        public string Omschrijving { get; set; }
        [Required]
        [NotMapped]
        public IFormFile? CameraImage { get; set; }
        public string? CameraImageUrl { get; set; }

        public string? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
        

    }
}
