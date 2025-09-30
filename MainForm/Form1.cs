using System;
using System.Linq;
using System.Windows.Forms;
using Logic;
using Models;
using Microsoft.VisualBasic;

namespace GameApp.UI
{
    public partial class MainForm : Form
    {
        private readonly GameLogic logic = new GameLogic();

        public MainForm()
        {
            InitializeComponent();
            RefreshGames();
            cbFilterGenre.Items.Clear();
            cbFilterGenre.Items.Add("Все");
            foreach (var genre in logic.GetAllGames().Select(g => g.Genre).Distinct())
            {
                cbFilterGenre.Items.Add(genre);
            }
            cbFilterGenre.SelectedIndex = 0;
        }

        private void RefreshGames()
        {
            dgvGames.DataSource = null;
            dgvGames.DataSource = logic.GetAllGames();
            cbFilterGenre.Items.Clear();
            cbFilterGenre.Items.Add("Все");
            foreach (var genre in logic.GetAllGames().Select(g => g.Genre).Distinct())
                cbFilterGenre.Items.Add(genre);
            cbFilterGenre.SelectedIndex = 0;
        }

        /// <summary>
        /// Добавляет новую игру через форму.
        /// </summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var dialog = new GameDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var game = new Game
                {
                    Name = dialog.GameName,
                    Genre = dialog.GameGenre,
                    Rating = dialog.GameRating
                };
                logic.AddGame(game);
                RefreshGames();
            }

        }
        /// <summary>
        /// Редактирует выбранную игру.
        /// </summary>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvGames.CurrentRow == null) return;
            var game = (Game)dgvGames.CurrentRow.DataBoundItem;

            var dialog = new GameDialog
            {
                GameName = game.Name,
                GameGenre = game.Genre,
                GameRating = game.Rating
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var updatedGame = new Game
                {
                    Id = game.Id,
                    Name = dialog.GameName,
                    Genre = dialog.GameGenre,
                    Rating = dialog.GameRating
                };
                logic.UpdateGame(updatedGame);
                RefreshGames();
            }
        }

        /// <summary>
        /// Удаляет выбранную игру.
        /// </summary>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvGames.CurrentRow == null)
            {
                MessageBox.Show("Выберите игру для удаления.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var game = (Game)dgvGames.CurrentRow.DataBoundItem;

            var result = MessageBox.Show(
                $"Вы уверены, что хотите удалить игру \"{game.Name}\"?",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                logic.DeleteGame(game.Id);
                RefreshGames();
            }
        }

        /// <summary>
        /// Фильтрует игры по выбранному жанру.
        /// </summary>
        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (cbFilterGenre.SelectedItem == null) return;

            string genre = cbFilterGenre.SelectedItem.ToString();

            if (genre == "Все")
            {
                RefreshGames(); // показываем все игры
            }
            else
            {
                dgvGames.DataSource = logic.FilterByGenre(genre);
            }
        }

        /// <summary>
        /// Показывает топ-3 игры по рейтингу.
        /// </summary>
        private void btnTopRated_Click(object sender, EventArgs e)
        {
            var topGames = logic.GetTopRatedGames(3);
            dgvGames.DataSource = topGames;
        }
    }
}
