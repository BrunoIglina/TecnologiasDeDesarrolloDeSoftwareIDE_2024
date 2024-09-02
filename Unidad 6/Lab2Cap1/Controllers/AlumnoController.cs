using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lab2Cap1.Models;
using Lab2Cap1.Context;
using System.Collections.Generic;
using System.Linq;

namespace Lab2Cap1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnoController : ControllerBase
    {
        private readonly MyDbContext _context;

        public AlumnoController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/alumno
        [HttpGet]
        public ActionResult<IEnumerable<Alumno>> GetAll()
        {
            return _context.Alumnoss.ToList();
        }

        // GET: api/alumno/{DNI}
        [HttpGet("{DNI}")]
        public ActionResult<Alumno> GetById(string DNI)
        {
            var alumno = _context.Alumnoss.Find(DNI);
            if (alumno == null)
            {
                return NotFound();
            }
            return alumno;
        }

        // POST: api/alumno
        [HttpPost]
        public ActionResult<Alumno> Create(Alumno alumno)
        {
            _context.Alumnoss.Add(alumno);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { DNI = alumno.DNI }, alumno);
        }

        // PUT: api/alumno/{DNI}
        [HttpPut("{DNI}")]
        public ActionResult Update(string DNI, Alumno alumno)
        {
            if (DNI != alumno.DNI.ToString())
            {
                return BadRequest();
            }
            _context.Entry(alumno).State = EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }

        // DELETE: api/alumno/{DNI}
        [HttpDelete("{DNI}")]
        public ActionResult<Alumno> Delete(string DNI)
        {
            var alumno = _context.Alumnoss.Find(DNI);
            if (alumno == null)
            {
                return NotFound();
            }
            _context.Remove(alumno);
            _context.SaveChanges();
            return alumno;
        }
    }
}
