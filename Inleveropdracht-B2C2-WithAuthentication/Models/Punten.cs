using System.ComponentModel.DataAnnotations;

namespace Inleveropdracht_B2C2_WithAuthentication.Models
{
    public class Punten
    {
        [Key]
        public int Id { get; set; }
        [Required]

        public int Rang { get; set; }
        public string Naam { get; set; }

        public int Points { get; set; }


    }
}
