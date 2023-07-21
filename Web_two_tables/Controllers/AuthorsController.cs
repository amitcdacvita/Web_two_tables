using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_two_tables.Models;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPITwoTable.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AuthorsController : ControllerBase
    {

        private readonly IAuthorinterface _repository;
        public AuthorsController(IAuthorinterface repository)
        {
            _repository = repository;

        }
        // GET: api/<AuthorsController>

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Author>>> GetAuthors()
        {
            if (await _repository.GetAllAuthor() == null)
            {
                return NotFound();
            }

            return await _repository.GetAllAuthor();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Author>> GetById(int id)
        {
            var author = await _repository.GetAuthor(id);
            return author == null ? NotFound() : author;
        }

        [HttpGet("{name}")]
        public ActionResult<IEnumerable<dynamic>> GetName(string name)
        {
            var author = _repository.GetName(name);
            return author == null ? NotFound() : author;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthor(int id, Author author)
        {
            if (id != author.AuthorId)
            {
                return BadRequest();
            }
            try
            {
                await _repository.Update(id, author);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_repository.GetAuthor(id) == null)
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

        // POST: api/Authors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Author>> PostAuthor(Author author)
        {
            await _repository.Add(author);
            return CreatedAtAction("PostAuthor", new { id = author.AuthorId }, author);
        }
        // DELETE: api/Author/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            if (_repository.GetAllAuthor() == null)
            {
                return NotFound();
            }

            await _repository.Delete(id);
            return NoContent();
        }
        
       

    }
}