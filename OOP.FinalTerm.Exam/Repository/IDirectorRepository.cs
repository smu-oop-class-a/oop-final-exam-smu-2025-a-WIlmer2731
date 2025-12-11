using OOP.FinalTerm.Exam.Model;

namespace OOP.FinalTerm.Exam.Repository
{
    public interface IDirectorRepository
    {
        /// <summary>
        /// Adds a new director to the database.
        /// </summary>
        void AddDirector(DirectorModel director);

        /// <summary>
        /// Retrieves all directors from the database.
        /// </summary>
        List<DirectorModel> GetAllDirectors();

        /// <summary>
        /// Retrieves a specific director by ID.
        /// </summary>
        DirectorModel GetDirectorById(int id);
    }
}