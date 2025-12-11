namespace OOP.FinalTerm.Exam.Repository
{
    public interface IMovieRepository
    {
        void AddMovie(MovieModel movie);
        List<MovieModel> GetAllMovies();
        MovieModel GetMovieById(int id);
        bool UpdateMovie(MovieModel movie);
        bool DeleteMovie(int id);
    }
}