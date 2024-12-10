using cinemateAPI.Data.DAO;
using cinemateAPI.Data.DAO.Entities;

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
    }
}
