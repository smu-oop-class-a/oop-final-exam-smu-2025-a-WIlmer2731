using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP.FinalTerm.Exam
{
    public partial class MovieControl : UserControl
    {
        private MovieModel _currentMovie;

        public MovieControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Populates the MovieControl with data from a MovieModel instance.
        /// </summary>
        /// <param name="movie">The MovieModel containing the movie data</param>
        public void SetMovieData(MovieModel movie)
        {
            _currentMovie = movie;

            lblMovieTitle.Text = movie.Title ?? "Unknown Title";
            lblMovieYear.Text = movie.DateReleased.Year.ToString();
            lblRating.Text = $"Rating: {movie.Ratings}/5";

            // Load and display the cover image from base64
            LoadCoverImage(movie);
        }

        /// <summary>
        /// Loads the cover image from the movie's base64 encoded Cover property.
        /// </summary>
        /// <param name="movie">The MovieModel containing the base64 image data</param>
        private void LoadCoverImage(MovieModel movie)
        {
            try
            {
                if (string.IsNullOrEmpty(movie.Cover))
                {
                    pBoxMovie.BackColor = Color.FromArgb(60, 60, 60);
                    pBoxMovie.Image = null;
                    return;
                }

                Image coverImage = movie.GetCoverImage();
                if (coverImage != null)
                {
                    pBoxMovie.Image = coverImage;
                }
                else
                {
                    pBoxMovie.BackColor = Color.FromArgb(60, 60, 60);
                }
            }
            catch
            {
                pBoxMovie.BackColor = Color.FromArgb(60, 60, 60);
                pBoxMovie.Image = null;
            }
        }

        /// <summary>
        /// Gets the current movie model associated with this control.
        /// </summary>
        /// <returns>The MovieModel instance</returns>
        public MovieModel GetMovieData()
        {
            return _currentMovie;
        }
    }
}
