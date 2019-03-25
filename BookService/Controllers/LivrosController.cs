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
    public class LivrosController : ApiController
    {
        private BookServiceContext db = new BookServiceContext();

        // GET: api/Livros
        public IQueryable<Livro> GetLivros()
        {
            return db.Livros
                    .Include(l => l.Autor);
        }

        // GET: api/Livros/5
        [ResponseType(typeof(Livro))]
        public async Task<IHttpActionResult> GetLivro(int id)
        {
            Livro livro = await db.Livros.FindAsync(id);
            if (livro == null)
            {
                return NotFound();
            }

            return Ok(livro);
        }

        // PUT: api/Livros/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutLivro(int id, Livro livro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != livro.Id)
            {
                return BadRequest();
            }

            db.Entry(livro).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LivroExists(id))
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

        // POST: api/Livros
        [ResponseType(typeof(Livro))]
        public async Task<IHttpActionResult> PostLivro(Livro livro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Livros.Add(livro);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = livro.Id }, livro);
        }

        // DELETE: api/Livros/5
        [ResponseType(typeof(Livro))]
        public async Task<IHttpActionResult> DeleteLivro(int id)
        {
            Livro livro = await db.Livros.FindAsync(id);
            if (livro == null)
            {
                return NotFound();
            }

            db.Livros.Remove(livro);
            await db.SaveChangesAsync();

            return Ok(livro);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LivroExists(int id)
        {
            return db.Livros.Count(e => e.Id == id) > 0;
        }
    }
}