using Inleveropdracht_B2C2_WithAuthentication.Data;
using Inleveropdracht_B2C2_WithAuthentication.Models;
using Microsoft.AspNetCore.Mvc;

namespace Inleveropdracht_B2C2_WithAuthentication.Controllers
{
    public class PuntenController : Controller
    {
        private readonly ApplicationDbContext database;

        public PuntenController(ApplicationDbContext database)
        {
            this.database = database;
        }

        public IActionResult Index()
        {
            IEnumerable<Punten> objPuntenList = database.Puntens;
            return View(objPuntenList);
        }
    }
}
