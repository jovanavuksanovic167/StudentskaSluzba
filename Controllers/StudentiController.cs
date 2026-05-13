using DrugiPutKlk.Data;
using DrugiPutKlk.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DrugiPutKlk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentiController : ControllerBase
    {

        [HttpGet]
        public ActionResult<List<StudentDTO>> GetStudenti(
            [FromQuery] string? FirstName,
            [FromQuery] string? LastName,
            [FromQuery] string? Index
            )
        {
            var query = InMemory.Students.AsQueryable();
            if (!string.IsNullOrWhiteSpace(FirstName))
                query = query.Where(s => s.FirstName.Equals(FirstName, StringComparison.OrdinalIgnoreCase));
            if (!string.IsNullOrWhiteSpace(LastName))
                query = query.Where(s => s.LastName.Equals(LastName, StringComparison.OrdinalIgnoreCase));
            if (!string.IsNullOrWhiteSpace(Index))
                query = query.Where(s => s.Index.Equals(Index, StringComparison.OrdinalIgnoreCase));

            var result = query.Select(s => new StudentDTO { FirstName = s.FirstName, LastName = s.LastName, Index = s.Index }).ToList();



            return Ok(result);
        
        }

        [HttpGet("top10")]
        public ActionResult<List<Top10DTO>> GetTop10() {
            var result = InMemory.PolozeniIspiti.GroupBy(pe => pe.Student).Select(s => new Top10DTO
            {
                FirstName = s.Key.FirstName,
                LastName = s.Key.LastName,
                Index = s.Key.Index,
                AverageGrade = s.Average(o => o.Grade)
            }).OrderByDescending(r => r.AverageGrade).Take(10).ToList();


            return Ok(result);
        
        }

        [HttpDelete]
        public ActionResult DeleteStudent([FromQuery] string Index) {

            var Student = InMemory.Students.FirstOrDefault(s => s.Index.Equals(Index, StringComparison.OrdinalIgnoreCase));
            InMemory.Students.Remove(Student);

            return Ok("Izbrisan je student");
        }

        [HttpPut]
        public ActionResult updateStudent([FromBody] StudentDTO input) {

            var Student = InMemory.Students.FirstOrDefault(s => s.Index.Equals(input.Index, StringComparison.OrdinalIgnoreCase));

            Student.FirstName = input.FirstName;
            Student.LastName = input.LastName;



            return Ok("Updateovan je student");
        }



    }
}
