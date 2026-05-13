using DrugiPutKlk.Data;
using DrugiPutKlk.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DrugiPutKlk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {

        [HttpGet]
        public ActionResult<List<StudentDTO>> GetStudents(
            [FromQuery] string? firstName,
            [FromQuery] string? lastName,
            [FromQuery] string? index)
        {
            var query = InMemory.Students.AsQueryable();
            if (!string.IsNullOrWhiteSpace(firstName)) {
                query = query.Where(s => s.FirstName.Contains(firstName, StringComparison.OrdinalIgnoreCase));
            
            }

            if (!string.IsNullOrWhiteSpace(lastName)) {
                query = query.Where(s => s.LastName.Contains(lastName, StringComparison.OrdinalIgnoreCase));
          
            }
            if (!string.IsNullOrWhiteSpace(index))
            {
                query = query.Where(s => s.Index.Contains(index, StringComparison.OrdinalIgnoreCase));

            }

            var result = query.Select(s => new StudentDTO { FirstName = s.FirstName, LastName = s.LastName, Index = s.Index }).ToList();

            return Ok(result);
        }

        [HttpGet("top10")]
        public ActionResult<List<Top10DTO>> GetTop10() {
            var result = InMemory.PolozeniIspiti.GroupBy(pi => pi.Student).Select(group => new Top10DTO
            {
                FirstName = group.Key.FirstName,
                LastName = group.Key.LastName,
                Index = group.Key.Index
        ,
                AverageGrade = group.Average(pi => pi.Grade)
            }).OrderByDescending(s => s.AverageGrade).Take(10).ToList();

            return Ok(result);
        
        
        
        
            
        }



    }
}
