using System;
using System.Drawing;
using System.Windows.Forms;

namespace GameApp.UI
{
    partial class GameDialog
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtName;
        private TextBox txtGenre;
        private NumericUpDown nudRating;
        private Button btnOK;
        private Button btnCancel;
        private Label lblName;
        private Label lblGenre;
        private Label lblRating;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            txtName = new TextBox();
            txtGenre = new TextBox();
            nudRating = new NumericUpDown();
            btnOK = new Button();
            btnCancel = new Button();
            lblName = new Label();
            lblGenre = new Label();
            lblRating = new Label();

            ((System.ComponentModel.ISupportInitialize)nudRating).BeginInit();
            SuspendLayout();

            // 
            // lblName
            // 
            lblName.Text = "Название:";
            lblName.Location = new Point(20, 20);
            lblName.AutoSize = true;

            // 
            // txtName
            // 
            txtName.Location = new Point(100, 18);
            txtName.Size = new Size(200, 22);

            // 
            // lblGenre
            // 
            lblGenre.Text = "Жанр:";
            lblGenre.Location = new Point(20, 60);
            lblGenre.AutoSize = true;

            // 
            // txtGenre
            // 
            txtGenre.Location = new Point(100, 58);
            txtGenre.Size = new Size(200, 22);

            // 
            // lblRating
            // 
            lblRating.Text = "Рейтинг:";
            lblRating.Location = new Point(20, 100);
            lblRating.AutoSize = true;

            // 
            // nudRating
            // 
            nudRating.Location = new Point(100, 98);
            nudRating.Minimum = 0;
            nudRating.Maximum = 10;
            nudRating.DecimalPlaces = 1;
            nudRating.Size = new Size(60, 22);

            // 
            // btnOK
            // 
            btnOK.Text = "OK";
            btnOK.Location = new Point(50, 140);
            btnOK.Size = new Size(80, 30);
            btnOK.Click += btnOK_Click;

            // 
            // btnCancel
            // 
            btnCancel.Text = "Отмена";
            btnCancel.Location = new Point(170, 140);
            btnCancel.Size = new Size(80, 30);
            btnCancel.Click += btnCancel_Click;

            // 
            // GameDialog
            // 
            ClientSize = new Size(340, 200);
            Controls.Add(lblName);
            Controls.Add(txtName);
            Controls.Add(lblGenre);
            Controls.Add(txtGenre);
            Controls.Add(lblRating);
            Controls.Add(nudRating);
            Controls.Add(btnOK);
            Controls.Add(btnCancel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Добавить/Редактировать игру";
            MaximizeBox = false;
            MinimizeBox = false;
            AcceptButton = btnOK;
            CancelButton = btnCancel;

            ((System.ComponentModel.ISupportInitialize)nudRating).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
