using DrugiPutKlk.Data;
using DrugiPutKlk.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace DrugiPutKlk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BulkController : ControllerBase
    {


        [HttpPost("bulk")]
        public ActionResult AddGrades([FromBody] UnosViseOcenaZaJedanPredmet input) {

            if (input == null) {
                return BadRequest();
            }
            if (string.IsNullOrWhiteSpace(input.Sifra)) {
                return BadRequest("dshshjd");
            }
            if (input.studeniSaOcenama == null) {
                return BadRequest();
            }


            if (input.studeniSaOcenama.Count < 5) {
                return BadRequest();
            }

            if (input.studeniSaOcenama.Any(g => g.Grade < 6 || g.Grade > 10)) {
                return BadRequest();
            
            }

            if (input.studeniSaOcenama.Any(s => string.IsNullOrWhiteSpace(s.Index))) {
                return BadRequest();
            }

            var predmet = InMemory.Predmeti.FirstOrDefault(p => p.Sifra.Equals(input.Sifra, StringComparison.OrdinalIgnoreCase));

            foreach (var unosOcene in input.studeniSaOcenama) {
                var student = InMemory.Students.FirstOrDefault(s => s.Index == unosOcene.Index);
                InMemory.PolozeniIspiti.Add(new Models.PolozenIspit { Student = student, Predmet = predmet, Grade = unosOcene.Grade });
            
            
            }

            return Ok();
        
        
        }
    }
}
