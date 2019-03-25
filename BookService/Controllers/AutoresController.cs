using BookService.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace BookService.Controllers
{
    public class AutoresController : ApiController
    {
        private BookServiceContext db = new BookServiceContext();

        // GET: api/Autores
        public IQueryable<Autor> GetAutores()
        {
            return db.Autores;
        }

        // GET: api/Autores/5
        [ResponseType(typeof(Autor))]
        public async Task<IHttpActionResult> GetAutor(int id)
        {
            Autor autor = await db.Autores.FindAsync(id);
            if (autor == null)
            {
                return NotFound();
            }

            return Ok(autor);
        }

        // PUT: api/Autores/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAutor(int id, Autor autor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != autor.Id)
            {
                return BadRequest();
            }

            db.Entry(autor).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AutorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Autores
        [ResponseType(typeof(Autor))]
        public async Task<IHttpActionResult> PostAutor(Autor autor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Autores.Add(autor);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = autor.Id }, autor);
        }

        // DELETE: api/Autores/5
        [ResponseType(typeof(Autor))]
        public async Task<IHttpActionResult> DeleteAutor(int id)
        {
            Autor autor = await db.Autores.FindAsync(id);
            if (autor == null)
            {
                return NotFound();
            }

            db.Autores.Remove(autor);
            await db.SaveChangesAsync();

            return Ok(autor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AutorExists(int id)
        {
            return db.Autores.Count(e => e.Id == id) > 0;
        }
    }
}