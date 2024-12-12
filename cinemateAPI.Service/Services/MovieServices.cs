using cinemateAPI.Data.DAO;
using cinemateAPI.Data.DAO.Entities;
using Microsoft.IdentityModel.Tokens;

namespace cinemateAPI.Core.Services
{
    public class MovieServices : IMovieServices {
        private MainDBContext _dbContext;

        public MovieServices(MainDBContext dbContext) { 
            _dbContext = dbContext;
        }
       
        public string AddMovie(int mvid, bool liked) {
            bool isAdded = false;
            MovieEntity? movieEntity = _dbContext.Movies.FirstOrDefault(m => m.MovieId == mvid);
            try {
                if (movieEntity == null)
                {
                    _dbContext.Movies.Add(new MovieEntity() { MovieId = mvid, IsLiked = liked });
                }
                else
                {
                    movieEntity.IsLiked = liked;
                }
                _dbContext.SaveChanges();
                return "Ok";
            } catch {
                return "Failed";
            }
        }

        public ICollection<int> GetMovies() {
            ICollection<int> ids = new HashSet<int>();

            foreach (var movie in _dbContext.Movies)
            {
                if (movie.IsLiked == true)
                {
                    ids.Add(movie.MovieId);
                }
            }

            if (_dbContext.Movies.IsNullOrEmpty() || ids.IsNullOrEmpty()) {
                ids.Add(-1);
            }
            return ids;
        }
    }
}
