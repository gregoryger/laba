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

        // �������� ��� ������� � �������� ������
        /// <summary>
        /// �������� ����, �������� �������������.
        /// </summary>
        public string GameName
        {
            get => txtName.Text;
            set => txtName.Text = value;
        }

        /// <summary>
        /// ���� ����, �������� �������������.
        /// </summary>
        public string GameGenre
        {
            get => txtGenre.Text;
            set => txtGenre.Text = value;
        }

        /// <summary>
        /// ������� ���� (0-10), �������� �������������.
        /// </summary>
        public double GameRating
        {
            get => (double)nudRating.Value;
            set => nudRating.Value = (decimal)value;
        }

        /// <summary>
        /// ��������� ������� ������ "OK". ��������� ������������ �������� ������.
        /// </summary>
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(GameName) || string.IsNullOrWhiteSpace(GameGenre))
            {
                MessageBox.Show("�������� � ���� �� ����� ���� �������.", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// ��������� ������� ������ "������". ��������� ����� ��� ����������.
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
