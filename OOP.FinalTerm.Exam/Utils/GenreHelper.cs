namespace OOP.FinalTerm.Exam.Utils
{
    #region helper [TOUCH IT NOT]
    /// <summary>
    /// Helper class to manage available movie genres throughout the application.
    /// </summary>
    public static class GenreHelper
    {
        /// <summary>
        /// List of all available genres used in the application.
        /// </summary>
        public static readonly string[] AvailableGenres =
        {
            "Action",
            "Comedy",
            "Drama",
            "Horror",
            "Romance",
            "Sci-Fi",
            "Thriller"
        };

        /// <summary>
        /// Gets the available genres as a list.
        /// </summary>
        /// <returns>List of available genres</returns>
        public static List<string> GetGenresList()
        {
            return AvailableGenres.ToList();
        }

        /// <summary>
        /// Gets the available genres as an array of objects for combo box binding.
        /// </summary>
        /// <returns>Array of genre objects</returns>
        public static object[] GetGenresAsObjects()
        {
            return AvailableGenres.Cast<object>().ToArray();
        }
    }
    #endregion
}