using DrugiPutKlk.Data;
using DrugiPutKlk.DTOs;
using DrugiPutKlk.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DrugiPutKlk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BulkingController : ControllerBase
    {

        [HttpGet]
        public ActionResult<List<PolozenIspit>> GetPolozeni() {
            return InMemory.PolozeniIspiti.ToList();
        
        }






        [HttpPost]
        public ActionResult addGrades([FromBody] UnosViseOcenaZaJedanPredmet input) {
            var Subject = InMemory.Predmeti.FirstOrDefault(p => p.Sifra.Equals(input.Sifra, StringComparison.OrdinalIgnoreCase));
            foreach (var s in input.studeniSaOcenama) {
                var Student = InMemory.Students.FirstOrDefault(stud => stud.Index.Equals(s.Index, StringComparison.OrdinalIgnoreCase));

                var PolozenIspit = new PolozenIspit { Predmet = Subject, Student = Student, Grade = s.Grade };
                InMemory.PolozeniIspiti.Add(PolozenIspit);
            
            }

            return Ok("Unete su ocene");

        }
    }
}
