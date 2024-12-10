using Microsoft.AspNetCore.Mvc;
using cinemateAPI.Core.Services;

namespace cinemateAPI.Controllers {
    public class MovieController : Controller {
        private IMovieServices movieServices;

        public MovieController(IMovieServices movieServices) {
            this.movieServices = movieServices;
        }

        [HttpGet("AddMovie")]
        public IActionResult AddMovie(int mvid, bool liked) {
            return Ok(movieServices.AddMovie(mvid, liked));
        }
    }
}
