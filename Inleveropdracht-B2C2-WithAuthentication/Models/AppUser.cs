using Microsoft.AspNetCore.Identity;

namespace Inleveropdracht_B2C2_WithAuthentication.Models
{
    public class AppUser : IdentityUser
    {
        public string Naam { get; set; }
        public string Achternaam { get; set; }
        public int Punten { get; set; } = 0;

        public virtual ICollection<Camera> Cameras { get; set; }


        
    }
}
