using System.IO;

namespace OOP.FinalTerm.Exam.Utils
{
    /// <summary>
    /// Helper class for managing database paths and configuration
    /// </summary>
    public static class DatabaseHelper
    {
        /// <summary>
        /// Gets the database folder path, creating it if it doesn't exist
        /// </summary>
        private static string GetDatabaseFolder()
        {
            string projectDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string databaseFolder = Path.Combine(projectDirectory, "Database");

            // Create the Database folder if it doesn't exist
            if (!Directory.Exists(databaseFolder))
            {
                Directory.CreateDirectory(databaseFolder);
            }

            return databaseFolder;
        }

        /// <summary>
        /// Gets the full path to the database file
        /// </summary>
        public static string GetDatabasePath()
        {
            return Path.Combine(GetDatabaseFolder(), "nitpleks.db");
        }
    }
}