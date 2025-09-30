using System;
using System.Drawing;
using System.Windows.Forms;

namespace GameApp.UI
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        private DataGridView dgvGames;
        private ComboBox cbFilterGenre;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnFilter;
        private Button btnTopRated;
        private Panel bottomPanel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dgvGames = new DataGridView();
            cbFilterGenre = new ComboBox();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            btnFilter = new Button();
            btnTopRated = new Button();
            bottomPanel = new Panel();
            this.AutoScaleMode = AutoScaleMode.Font;
            this.MinimumSize = new Size(800, 500);
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.ClientSize = new Size(1021, 551);
            this.Name = "MainForm";
            this.Text = "GameApp";
            dgvGames.Dock = DockStyle.Fill;
            dgvGames.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGames.ReadOnly = true;
            dgvGames.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvGames.RowHeadersWidth = 82;
            bottomPanel.Dock = DockStyle.Bottom;
            bottomPanel.Height = 60;
            bottomPanel.Padding = new Padding(10);
            cbFilterGenre.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFilterGenre.Location = new Point(10, 15);
            cbFilterGenre.Size = new Size(150, 23);
            btnFilter.Text = "Фильтр";
            btnFilter.Location = new Point(170, 15);
            btnFilter.Size = new Size(75, 23);
            btnFilter.Click += btnFilter_Click;
            btnTopRated.Text = "Топ 3";
            btnTopRated.Location = new Point(250, 15);
            btnTopRated.Size = new Size(75, 23);
            btnTopRated.Click += btnTopRated_Click;
            btnAdd.Text = "Добавить";
            btnAdd.Location = new Point(340, 15);
            btnAdd.Size = new Size(90, 23);
            btnAdd.Click += btnAdd_Click;
            btnEdit.Text = "Редактировать";
            btnEdit.Location = new Point(440, 15);
            btnEdit.Size = new Size(110, 23);
            btnEdit.Click += btnEdit_Click;
            btnDelete.Text = "Удалить";
            btnDelete.Location = new Point(560, 15);
            btnDelete.Size = new Size(90, 23);
            btnDelete.Click += btnDelete_Click;
            bottomPanel.Controls.Add(cbFilterGenre);
            bottomPanel.Controls.Add(btnFilter);
            bottomPanel.Controls.Add(btnTopRated);
            bottomPanel.Controls.Add(btnAdd);
            bottomPanel.Controls.Add(btnEdit);
            bottomPanel.Controls.Add(btnDelete);
            this.Controls.Add(dgvGames);
            this.Controls.Add(bottomPanel);
        }
    }
}
