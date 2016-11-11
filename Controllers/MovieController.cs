using System.Linq;
using System.Web.Http;
using Movies.Infra;

namespace Movies.Controllers
{
    public class MovieController : ApiController
    {
        private readonly MoviesDbSet _dbSet;

        public MovieController()
        {
            _dbSet = new MoviesDbSet();
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var movies = _dbSet.Movies.ToList();
            return Ok(new { movies  });
        }

        [HttpGet]
        public IHttpActionResult SearchByTitle(string title)
        {
            var movie = _dbSet.Movies.FirstOrDefault(m => m.title == title);
            if (movie == null)
                return NotFound();

            return Ok(new { movie });
        }

        [HttpPost]
        public IHttpActionResult Add([FromBody]Movie movie)
        {
            _dbSet.Movies.Add(movie);
            _dbSet.SaveChanges();

            return Ok();
        }

        [HttpPost]
        public IHttpActionResult Delete([FromBody]Movie moviet)
        {
            var movie = _dbSet.Movies.FirstOrDefault(m => m.title == moviet.title);
            if (movie == null)
                return NotFound();

            _dbSet.Movies.Remove(movie);
            _dbSet.SaveChanges();

            return Ok();
        }
    }
}
