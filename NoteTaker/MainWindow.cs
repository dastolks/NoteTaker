using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoteTaker
{
    public partial class MainWindow : Form
    {
        DataTable table;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            table = new DataTable();
            table.Columns.Add("Title", typeof(String));
            table.Columns.Add("Messages", typeof(String));

            dataGridViewMain.DataSource = table;
            dataGridViewMain.Columns["Messages"].Visible = false;
            dataGridViewMain.Columns["Title"].Width = dataGridViewMain.Size.Width-3;
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            txtTitle.Clear();
            txtMessage.Clear();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            table.Rows.Add(txtTitle.Text, txtMessage.Text);

            txtTitle.Clear();
            txtMessage.Clear();
        }

        private void buttonRead_Click(object sender, EventArgs e)
        {
            int index = dataGridViewMain.CurrentCell.RowIndex;

            if(index > -1)
            {
                txtTitle.Text = table.Rows[index].ItemArray[0].ToString();
                txtMessage.Text = table.Rows[index].ItemArray[1].ToString();
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            int index = dataGridViewMain.CurrentCell.RowIndex;
            table.Rows[index].Delete();
        }
    }
}
