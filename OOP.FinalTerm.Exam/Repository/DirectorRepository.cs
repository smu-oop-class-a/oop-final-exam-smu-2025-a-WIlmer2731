using OOP.FinalTerm.Exam.Model;
using SQLite;

namespace OOP.FinalTerm.Exam.Repository
{
    public class DirectorRepository : IDirectorRepository
    {
        private readonly ISQLiteConnection _dbConnection;

        public DirectorRepository()
        {
            //TODO: Uncomment and implement the database connection
            //_dbConnection = new SQLiteConnection(DatabaseHelper.GetDatabasePath());            
            //_dbConnection.CreateTable<DirectorModel>();
        }

        /// <summary>
        /// Adds a new director to the database.
        /// </summary>
        /// <param name="director">The director object to add</param>
        public void AddDirector(DirectorModel director)
        {
            // TODO: Students will implement this method
            // Hint: Use _dbConnection.Insert(director);
        }

        /// <summary>
        /// Retrieves all directors from the database.
        /// </summary>
        /// <returns>List of all directors</returns>
        public List<DirectorModel> GetAllDirectors()
        {
            // TODO: Students will implement this method
            // Hint: Use _dbConnection.Table<DirectorModel>().ToList();
            return new List<DirectorModel>(); //remove this
        }

        /// <summary>
        /// Retrieves a specific director by their ID.
        /// </summary>
        /// <param name="id">The director ID to search for</param>
        /// <returns>Director object if found, null otherwise</returns>
        public DirectorModel GetDirectorById(int id)
        {
            // TODO: Students will implement this method
            // Hint: Use _dbConnection.Find<DirectorModel>(id);
            return null; //remove this
        }
    }
}