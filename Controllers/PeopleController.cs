using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackendSico.Context;
using BackendSico.Models;
using Azure;
using BackendSico.Interfaces;
using BackendSico.Models.Dtos;

namespace BackendSico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        //private readonly ApplicationDbContext _context;
        private readonly IPerson _person;
        protected ResponseDto _response;

        public PeopleController(IPerson person)
        {
            _person = person;
            _response = new ResponseDto();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPerson(int id)
        {
            var person = await _person.GetPersonById(id);

            if (person == null)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "This person don't exist";
                return NotFound(_response);
            }
            _response.IsSuccess = true;
            _response.Result = person;
            _response.DisplayMessage = "Person information";
            return Ok(_response);
        }

        // GET: api/People
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetPeople()
        {
            try
            {
                var list = await _person.GetPeople();
                _response.IsSuccess = true;
                _response.Result = list;
                _response.DisplayMessage = "People list";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }

            return Ok(_response);
        }


        // POST: api/People
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Person>> PostPerson(Person person)
        {
            try
            {
                Person model = await _person.CreatePerson(person);
                _response.IsSuccess = true;
                _response.Result = model;
                _response.DisplayMessage = "Person create";
                return CreatedAtAction("GetPerson", new { id = model.id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error to save register";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return BadRequest(_response);
            }
        }

        /*
                // GET: api/People/5
                [HttpGet("{id}")]
                public async Task<ActionResult<Person>> GetPerson(int id)
                {
                  if (_context.People == null)
                  {
                      return NotFound();
                  }
                    var person = await _context.People.FindAsync(id);

                    if (person == null)
                    {
                        return NotFound();
                    }

                    return person;
                }


                // PUT: api/People/5
                // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
                [HttpPut("{id}")]
                public async Task<IActionResult> PutPerson(int id, Person person)
                {
                    if (id != person.id)
                    {
                        return BadRequest();
                    }

                    _context.Entry(person).State = EntityState.Modified;

                    try
                    {
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!PersonExists(id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }

                    return NoContent();
                }

                // POST: api/People
                // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
                [HttpPost]
                public async Task<ActionResult<Person>> PostPerson(Person person)
                {
                  if (_context.People == null)
                  {
                      return Problem("Entity set 'ApplicationDbContext.People'  is null.");
                  }
                    _context.People.Add(person);
                    await _context.SaveChangesAsync();

                    return CreatedAtAction("GetPerson", new { id = person.id }, person);
                }

                // DELETE: api/People/5
                [HttpDelete("{id}")]
                public async Task<IActionResult> DeletePerson(int id)
                {
                    if (_context.People == null)
                    {
                        return NotFound();
                    }
                    var person = await _context.People.FindAsync(id);
                    if (person == null)
                    {
                        return NotFound();
                    }

                    _context.People.Remove(person);
                    await _context.SaveChangesAsync();

                    return NoContent();
                }

                private bool PersonExists(int id)
                {
                    return (_context.People?.Any(e => e.id == id)).GetValueOrDefault();
                }
        */
    }
}
