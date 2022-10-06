using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1Spreadsheet
{
    public partial class MainForm : Form
    {
        private string rows = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private string cols = "1234567890";

        int currRow, currCol;

        public Dictionary<string, MyCell> dictOfCellsViaId = new Dictionary<string, MyCell>();

        private void CreateDataGrid(int rows, int cols)
        {
            for (int col = 0; col < cols; col++)
            {
                DataGridViewColumn vColumn = new DataGridViewColumn();
                MyCell cell = new MyCell();
                vColumn.CellTemplate = cell;
                vColumn.HeaderText = ((char)(col + 65)).ToString();
                vColumn.Name = ((char)(col + 65)).ToString();

                dataGridView.Columns.Add(vColumn);
            }

            DataGridViewRow vRow = new DataGridViewRow();
            dataGridView.Rows.Add(vRow);
            for (int row = 0; row < rows; row++)
            {
                dataGridView.Rows.Add();
            }
        }

        private void SetRowNum(DataGridView dataGridView)
        {
            for (int i = 0; i < dataGridView.RowCount; i++)
            {
                // Set row name
                dataGridView.Rows[i].HeaderCell.Value = (i+1).ToString();
            }
        }

        public MainForm()
        {
            InitializeComponent();
            CreateDataGrid(8, 8);

            SetRowNum(dataGridView);
          


    }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
