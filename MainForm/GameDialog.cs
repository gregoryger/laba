using System;
using System.Windows.Forms;
using System.Xml.Linq;

namespace GameApp.UI
{
    public partial class GameDialog : Form
    {
        public GameDialog()
        {
            InitializeComponent();
        }

        // Свойства для доступа к введённым данным
        /// <summary>
        /// Название игры, введённое пользователем.
        /// </summary>
        public string GameName
        {
            get => txtName.Text;
            set => txtName.Text = value;
        }

        /// <summary>
        /// Жанр игры, введённый пользователем.
        /// </summary>
        public string GameGenre
        {
            get => txtGenre.Text;
            set => txtGenre.Text = value;
        }

        /// <summary>
        /// Рейтинг игры (0-10), введённый пользователем.
        /// </summary>
        public double GameRating
        {
            get => (double)nudRating.Value;
            set => nudRating.Value = (decimal)value;
        }

        /// <summary>
        /// Обработка нажатия кнопки "OK". Проверяет корректность введённых данных.
        /// </summary>
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(GameName) || string.IsNullOrWhiteSpace(GameGenre))
            {
                MessageBox.Show("Название и жанр не могут быть пустыми.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// Обработка нажатия кнопки "Отмена". Закрывает форму без сохранения.
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
