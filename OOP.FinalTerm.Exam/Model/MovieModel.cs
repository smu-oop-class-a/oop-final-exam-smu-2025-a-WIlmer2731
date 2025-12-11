using SQLite;

namespace OOP.FinalTerm.Exam
{
    public class MovieModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateReleased { get; set; }
        public string Genre { get; set; }
        public string Cover { get; set; }
        public int Ratings { get; set; }

        #region methods [TOUCH IT NOT.]
        /// <summary>
        /// Converts a local image file to base64 string and stores it in the Cover property.
        /// </summary>
        /// <param name="imagePath">Path to the local image file</param>
        /// <returns>True if conversion was successful; otherwise false</returns>
        public bool SetCoverFromFile(string imagePath)
        {
            try
            {
                if (!File.Exists(imagePath))
                {
                    return false;
                }

                byte[] imageData = File.ReadAllBytes(imagePath);
                Cover = Convert.ToBase64String(imageData);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Converts the base64 Cover string to an Image object.
        /// </summary>
        /// <returns>Image object if conversion is successful; otherwise null</returns>
        public Image GetCoverImage()
        {
            try
            {
                if (string.IsNullOrEmpty(Cover))
                {
                    return null;
                }

                byte[] imageData = Convert.FromBase64String(Cover);
                using (MemoryStream ms = new MemoryStream(imageData))
                {
                    return Image.FromStream(ms);
                }
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Saves the base64 Cover image to a local file.
        /// </summary>
        /// <param name="outputPath">Path where the image will be saved</param>
        /// <returns>True if save was successful; otherwise false</returns>
        public bool SaveCoverToFile(string outputPath)
        {
            try
            {
                if (string.IsNullOrEmpty(Cover))
                {
                    return false;
                }

                byte[] imageData = Convert.FromBase64String(Cover);
                File.WriteAllBytes(outputPath, imageData);
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion
    }
}
