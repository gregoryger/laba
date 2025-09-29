using System;
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
            this.AutoScaleMode = AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.MinimumSize = new Size(800, 500); // задаём минимальный размер
            dgvGames.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            cbFilterGenre.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            btnAdd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEdit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDelete.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnFilter.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnTopRated.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ((System.ComponentModel.ISupportInitialize)dgvGames).BeginInit();
            SuspendLayout();
            dgvGames.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGames.Location = new Point(12, 12);
            dgvGames.Name = "dgvGames";
            dgvGames.ReadOnly = true;
            dgvGames.RowHeadersWidth = 82;
            dgvGames.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvGames.Size = new Size(560, 300);
            dgvGames.TabIndex = 0;
            cbFilterGenre.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFilterGenre.Location = new Point(12, 320);
            cbFilterGenre.Name = "cbFilterGenre";
            cbFilterGenre.Size = new Size(150, 40);
            cbFilterGenre.TabIndex = 1;
            btnAdd.Location = new Point(12, 350);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 4;
            btnAdd.Text = "Добавить";
            btnAdd.Click += btnAdd_Click;
            btnEdit.Location = new Point(95, 350);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(75, 23);
            btnEdit.TabIndex = 5;
            btnEdit.Text = "Редактировать";
            btnEdit.Click += btnEdit_Click;
            btnDelete.Location = new Point(180, 350);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 6;
            btnDelete.Text = "Удалить";
            btnDelete.Click += btnDelete_Click;
            btnFilter.Location = new Point(170, 320);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(75, 23);
            btnFilter.TabIndex = 2;
            btnFilter.Text = "Фильтр";
            btnFilter.Click += btnFilter_Click;
            btnTopRated.Location = new Point(250, 320);
            btnTopRated.Name = "btnTopRated";
            btnTopRated.Size = new Size(120, 23);
            btnTopRated.TabIndex = 3;
            btnTopRated.Text = "Топ 3";
            btnTopRated.Click += btnTopRated_Click;
            ClientSize = new Size(1021, 551);
            Controls.Add(dgvGames);
            Controls.Add(cbFilterGenre);
            Controls.Add(btnFilter);
            Controls.Add(btnTopRated);
            Controls.Add(btnAdd);
            Controls.Add(btnEdit);
            Controls.Add(btnDelete);
            Name = "MainForm";
            Text = "GameApp";
            ((System.ComponentModel.ISupportInitialize)dgvGames).EndInit();
            ResumeLayout(false);
        }
    }
}
