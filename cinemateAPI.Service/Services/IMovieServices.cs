using System.Collections;

namespace cinemateAPI.Core.Services {
    public interface IMovieServices {
        public string AddMovie(int mvid, bool liked);
        public ICollection<int> GetMovies();
    }
}
