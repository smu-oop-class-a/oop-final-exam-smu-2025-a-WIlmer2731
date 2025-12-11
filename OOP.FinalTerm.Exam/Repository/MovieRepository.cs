using SQLite;
using OOP.FinalTerm.Exam.Utils;

namespace OOP.FinalTerm.Exam.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ISQLiteConnection _dbConnection;

        public MovieRepository()
        {
            _dbConnection = new SQLiteConnection(DatabaseHelper.GetDatabasePath());
            _dbConnection.CreateTable<MovieModel>();
        }

        public void AddMovie(MovieModel movie)
        {
            _dbConnection.Insert(movie);
        }

        public List<MovieModel> GetAllMovies()
        {
           return _dbConnection.Table<MovieModel>().ToList();
        }

        public MovieModel GetMovieById(int id)
        {
            return _dbConnection.Find<MovieModel>(id);
        }

        public bool UpdateMovie(MovieModel movie)
        {
            if (MovieExists(movie))
            {
                _dbConnection.Update(movie);
                return true;
            }

            return false;
        }

        public bool DeleteMovie(int id)
        {
            if(MovieExists(new MovieModel { Id = id }))
            {
                _dbConnection.Delete<MovieModel>(id);
                return true;
            }
            return false;
        }

        private bool MovieExists(MovieModel movie)
        {
            return GetMovieById(movie.Id) != null;
        }
    }
}
