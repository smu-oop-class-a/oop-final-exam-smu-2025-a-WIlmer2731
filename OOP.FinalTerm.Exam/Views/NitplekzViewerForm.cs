using OOP.FinalTerm.Exam.Repository;
using OOP.FinalTerm.Exam.Utils;
using System.Runtime.InteropServices;

namespace OOP.FinalTerm.Exam
{
    public partial class NitplekzViewerForm : Form
    {
        private readonly IMovieRepository _movieRepository;
        private List<MovieModel> _allMovies = new();
        private Dictionary<string, Button> _genreButtons = new();

        public NitplekzViewerForm()
        {
            InitializeComponent();
            _movieRepository = new MovieRepository();
            ApplyNetflixTheme();
            CreateGenreFilterButtons();
            AttachButtonEvents();
            LoadAllMovies();
        }

        /// <summary>
        /// Creates filter buttons dynamically from the GenreHelper.AvailableGenres list.
        /// </summary>
        private void CreateGenreFilterButtons()
        {
            try
            {
                // Find panel2
                Panel panel2 = null;
                var panel1 = this.Controls.OfType<Panel>().FirstOrDefault(p => p.Name == "panel1");
                if (panel1 != null)
                {
                    var tableLayoutPanel = panel1.Controls.OfType<TableLayoutPanel>().FirstOrDefault();
                    if (tableLayoutPanel != null)
                    {
                        panel2 = tableLayoutPanel.Controls.OfType<Panel>().FirstOrDefault(p => p.Name == "panel2");
                    }
                }

                if (panel2 == null)
                    return;

                panel2.Controls.Clear();

                // Create "All Movies" button
                var btnAllMovies = new Button
                {
                    Text = "All",
                    Width = 166,
                    Height = 40,
                    BackColor = Color.FromArgb(20, 20, 20),
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                    FlatStyle = FlatStyle.Flat,
                    Cursor = Cursors.Hand,
                    Name = "btnAllMovies",
                    Margin = new Padding(3)
                };
                btnAllMovies.FlatAppearance.BorderSize = 0;
                btnAllMovies.MouseEnter += Button_MouseEnter;
                btnAllMovies.MouseLeave += Button_MouseLeave;
                btnAllMovies.Click += (s, e) => FilterMoviesByGenre(null);
                panel2.Controls.Add(btnAllMovies);

                int yPosition = 45;

                // Create genre filter buttons
                foreach (var genre in GenreHelper.AvailableGenres)
                {
                    var btnGenre = new Button
                    {
                        Text = genre,
                        Width = 166,
                        Height = 40,
                        Location = new Point(3, yPosition),
                        BackColor = Color.FromArgb(20, 20, 20),
                        ForeColor = Color.White,
                        Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                        FlatStyle = FlatStyle.Flat,
                        Cursor = Cursors.Hand,
                        Name = $"btn{genre.Replace("-", "").Replace(" ", "")}"
                    };
                    btnGenre.FlatAppearance.BorderSize = 0;
                    btnGenre.MouseEnter += Button_MouseEnter;
                    btnGenre.MouseLeave += Button_MouseLeave;

                    string currentGenre = genre;
                    btnGenre.Click += (s, e) => FilterMoviesByGenre(currentGenre);

                    _genreButtons[genre] = btnGenre;
                    panel2.Controls.Add(btnGenre);

                    yPosition += 45;
                }

                panel2.AutoScroll = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating genre buttons: {ex.Message}\n\nStack: {ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AttachButtonEvents()
        {
            // Events are attached in CreateGenreFilterButtons
        }

        private void LoadAllMovies()
        {
            try
            {
                _allMovies = _movieRepository.GetAllMovies();
                DisplayMovies(_allMovies);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading movies: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FilterMoviesByGenre(string? genre)
        {
            if (string.IsNullOrEmpty(genre))
            {
                DisplayMovies(_allMovies);
            }
            else
            {
                var filteredMovies = _allMovies.Where(m => m.Genre.Equals(genre, StringComparison.OrdinalIgnoreCase)).ToList();
                DisplayMovies(filteredMovies);
            }
        }

        private void DisplayMovies(List<MovieModel> movies)
        {
            movieListPanel.Controls.Clear();

            if (movies.Count == 0)
            {
                var emptyLabel = new Label
                {
                    Text = "No movies found",
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                    AutoSize = true,
                    TextAlign = ContentAlignment.MiddleCenter
                };
                movieListPanel.Controls.Add(emptyLabel);
                return;
            }

            // Calculate the number of items per row based on panel width
            // MovieControl width is 250 pixels
            int movieControlWidth = 250;
            int movieControlHeight = 300;
            int padding = 15;
            int itemSpacing = 10;
            
            // Available width for movies
            int availableWidth = movieListPanel.Width - (padding * 2) - 17; // 17 for scrollbar
            
            // Calculate items per row (3-4 items max)
            int itemsPerRow = availableWidth / (movieControlWidth + itemSpacing);
            itemsPerRow = Math.Max(1, Math.Min(itemsPerRow, 4)); // Min 1, Max 4 items per row

            int controlCount = 0;

            foreach (var movie in movies)
            {
                var movieControl = new MovieControl();
                movieControl.SetMovieData(movie);
                movieControl.Margin = new Padding(itemSpacing / 2);
                movieListPanel.Controls.Add(movieControl);

                controlCount++;

                // Force new row after every itemsPerRow items (optional visual separator)
                // This is handled automatically by FlowLayoutPanel with WrapContents = true
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            const string correctCode = "1234"; // Change to your desired access code
            string userInput = PromptForAccessCode();

            if (string.IsNullOrEmpty(userInput))
            {
                return; // User cancelled
            }

            if (userInput == correctCode)
            {
                MessageBox.Show("✓ Access granted! Welcome to Settings.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                var settingsForm = new SettingsForm(_movieRepository);
                settingsForm.ShowDialog();
                
                // Auto-refresh the movie list after settings form closes
                LoadAllMovies();
            }
            else
            {
                MessageBox.Show("✗ Invalid access code. Please try again.", "Access Denied",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #region Theme & UI Styling
        private readonly Color _netflixRed = Color.FromArgb(221, 0, 0);
        private readonly Color _darkBackground = Color.FromArgb(20, 20, 20);
        private readonly Color _hoverColor = Color.FromArgb(50, 50, 50);

        private void ApplyNetflixTheme()
        {
            // Form styling
            this.BackColor = _darkBackground;
            this.ForeColor = Color.White;
        }

        private void StyleButton(Button button)
        {
            button.BackColor = _darkBackground;
            button.ForeColor = Color.White;
            button.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Cursor = Cursors.Hand;
        }

        private IEnumerable<Control> GetAllControls(Control container)
        {
            foreach (Control control in container.Controls)
            {
                yield return control;
                foreach (Control child in GetAllControls(control))
                {
                    yield return child;
                }
            }
        }

        private void Button_MouseEnter(object? sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = _hoverColor;
                button.FlatAppearance.BorderSize = 2;
                button.FlatAppearance.BorderColor = _netflixRed;
            }
        }

        private void Button_MouseLeave(object? sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = _darkBackground;
                button.FlatAppearance.BorderSize = 0;
            }
        }

        private string? PromptForAccessCode()
        {
            Form promptForm = new Form()
            {
                Text = "Settings Access Code",
                Width = 320,
                Height = 180,
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                BackColor = _darkBackground,
                ForeColor = Color.White
            };

            Label label = new Label()
            {
                Left = 20,
                Top = 20,
                Width = 270,
                Height = 30,
                Text = "Enter Access Code:",
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = Color.White
            };

            TextBox textBox = new TextBox()
            {
                Left = 20,
                Top = 55,
                Width = 270,
                Height = 30,
                Font = new Font("Segoe UI", 10F),
                BackColor = Color.FromArgb(40, 40, 40),
                ForeColor = Color.White,
                UseSystemPasswordChar = true,
                BorderStyle = BorderStyle.FixedSingle
            };

            Button okButton = new Button()
            {
                Text = "OK",
                Left = 160,
                Top = 105,
                Width = 60,
                Height = 30,
                DialogResult = DialogResult.OK,
                BackColor = _netflixRed,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            okButton.FlatAppearance.BorderSize = 0;

            Button cancelButton = new Button()
            {
                Text = "Cancel",
                Left = 230,
                Top = 105,
                Width = 60,
                Height = 30,
                DialogResult = DialogResult.Cancel,
                BackColor = Color.FromArgb(60, 60, 60),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            cancelButton.FlatAppearance.BorderSize = 0;

            promptForm.Controls.Add(label);
            promptForm.Controls.Add(textBox);
            promptForm.Controls.Add(okButton);
            promptForm.Controls.Add(cancelButton);
            promptForm.AcceptButton = okButton;
            promptForm.CancelButton = cancelButton;

            return promptForm.ShowDialog() == DialogResult.OK ? textBox.Text : null;
        }
        #endregion

        private void NitplekzViewerForm_Load(object sender, EventArgs e)
        {

        }
    }

    /// <summary>
    /// Helper class to customize scrollbar appearance for WinForms controls.
    /// Provides Netflix-themed thin scrollbars that appear on hover.
    /// </summary>
    public static class ScrollbarCustomizer
    {
        private const int SB_HORZ = 0;
        private const int SB_VERT = 1;
        private const int SB_CTL = 2;
        private const int SIF_RANGE = 0x0001;
        private const int SIF_PAGE = 0x0002;
        private const int SIF_POS = 0x0004;
        private const int SIF_DISABLENOSCROLL = 0x0008;
        private const int SIF_TRACKPOS = 0x0010;
        private const int SIF_ALL = SIF_RANGE | SIF_PAGE | SIF_POS | SIF_TRACKPOS;

        [DllImport("user32.dll")]
        private static extern int SetScrollInfo(IntPtr hwnd, int fnBar, ref SCROLLINFO lpsi, bool fRedraw);

        [DllImport("user32.dll")]
        private static extern bool GetScrollInfo(IntPtr hwnd, int fnBar, ref SCROLLINFO lpsi);

        [StructLayout(LayoutKind.Sequential)]
        public struct SCROLLINFO
        {
            public uint cbSize;
            public uint fMask;
            public int nMin;
            public int nMax;
            public uint nPage;
            public int nPos;
            public int nTrackPos;
        }

        /// <summary>
        /// Applies Netflix-themed scrollbar styling to a control with hover effect.
        /// </summary>
        /// <param name="control">The control to apply scrollbar styling to</param>
        /// <param name="netflixRed">Netflix red color (default: RGB 221, 0, 0)</param>
        public static void ApplyNetflixScrollbar(Control control, Color? netflixRed = null)
        {
            netflixRed ??= Color.FromArgb(221, 0, 0);

            // Set scrollbar width to thin (8 pixels)
            SetScrollbarWidth(control.Handle, 8);

            // Add hover event handlers for visual feedback
            control.MouseEnter += (s, e) =>
            {
                if (control is Panel or FlowLayoutPanel)
                {
                    control.Focus();
                }
            };

            control.MouseLeave += (s, e) =>
            {
                if (control is Panel or FlowLayoutPanel)
                {
                    control.Parent?.Focus();
                }
            };
        }

        /// <summary>
        /// Sets the width of the vertical scrollbar.
        /// </summary>
        /// <param name="hwnd">Handle to the control</param>
        /// <param name="width">Width in pixels (thin: 8-10, normal: 15-17)</param>
        private static void SetScrollbarWidth(IntPtr hwnd, int width)
        {
            try
            {
                // Use Windows API to set scrollbar width
                int result = NativeMethods.SetWindowPos(hwnd, IntPtr.Zero, 0, 0, 0, 0,
                    NativeMethods.SWP_NOSIZE | NativeMethods.SWP_NOMOVE | NativeMethods.SWP_NOZORDER);
            }
            catch
            {
                // Silently fail if native methods not available
            }
        }
    }

    /// <summary>
    /// Native Windows API methods for scrollbar customization.
    /// </summary>
    internal static class NativeMethods
    {
        internal const int SWP_NOSIZE = 0x0001;
        internal const int SWP_NOMOVE = 0x0002;
        internal const int SWP_NOZORDER = 0x0004;

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern int SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, int uFlags);

        [DllImport("user32.dll")]
        internal static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        [DllImport("user32.dll")]
        internal static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        internal static extern bool SetWindowLong(IntPtr hWnd, int nIndex, long dwNewLong);

        [DllImport("user32.dll")]
        internal static extern long GetWindowLong(IntPtr hWnd, int nIndex);

        // Window message constants
        internal const int WM_VSCROLL = 0x0115;
        internal const int WM_HSCROLL = 0x0114;
        internal const int GWL_STYLE = -16;
        internal const int WS_VSCROLL = 0x00200000;
        internal const int WS_HSCROLL = 0x00100000;
    }
}
