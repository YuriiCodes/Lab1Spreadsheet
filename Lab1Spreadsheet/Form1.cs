﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Lab1Spreadsheet
{
    public partial class MainForm : Form
    {
        private string rows = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private string cols = "1234567890";

        int currRow, currCol;

        // We need this variable to keep a reference to the cell whoose expression we will edit.
        string currCellId = "";

        public Dictionary<string, MyCell> dictOfCellsViaId = new Dictionary<string, MyCell>();

        private void showCurrentCellId(DataGridView dgv)
        {
            int currentCellCol = dgv.CurrentCell.ColumnIndex;
            int currentCellRow = dgv.CurrentCell.RowIndex;

            string currentCellName = convertColAndRowToCellID(currentCellCol, currentCellRow);
            MessageBox.Show(currentCellName, "ID", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void addRow(DataGridView dgv)
        {
            DataGridViewRow row = new DataGridViewRow();
            dgv.Rows.Add(row);
            SetRowNum(dgv);
        }

        private void addColumn(DataGridView dgv)
        {
            DataGridViewColumn column = new DataGridViewColumn();
            DataGridViewCell cell = new DataGridViewTextBoxCell();
            column.CellTemplate = cell;
            int k = dgv.ColumnCount - 1;

            if (k > 24)
            {
                MessageBox.Show("Досягнута максимальна кількість колонок", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            };

            string n = dgv.Columns[k].Name;

            int j = rows.IndexOf(n);
            char c = rows[j + 1];

            string cc = c.ToString();

            column.HeaderText = cc;
            column.Name = cc;

            dgv.Columns.Add(column);
            j = dgv.ColumnCount - 1;

            for (int i = 0; i < dgv.RowCount - 1; i++)
            {
                k = j + 65;
                string cell_name = (char)k + (i + 1).ToString();
                MyCell newCell = new MyCell();
                newCell.Value = "0";
                newCell.Exp = "0";
                newCell.Dependencies.Add("");
                try
                {
                    dictOfCellsViaId.Add(cell_name, newCell);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

        }

        public bool validateIfCurrentCellPresent(DataGridView dgv)
        {
            if (dgv.CurrentCell == null)
            {
                MessageBox.Show("Будь ласка, виберіть клітинку", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private string convertColIndexToChar(int index)
        {
            return ((char)(index + 65)).ToString();
        }

        // This function is called when user clicks on cell.
        public void showCurrentCellExpt(DataGridView dgv, TextBox txt) {
            Debug.WriteLine("CLicked on Cell");

            currCol = dgv.CurrentCell.ColumnIndex;
            currRow = dgv.CurrentCell.RowIndex;

            currCellId = convertColAndRowToCellID(currCol, currRow);
            
            // When the current cell is in the row/col that was later added by user, it is not placed into dict by default, so we put it there first.
            if (!dictOfCellsViaId.ContainsKey(currCellId))
            {
                MyCell newCell = new MyCell();
                dictOfCellsViaId.Add(currCellId, newCell);
            }
            labelForExprInp.Text = "Expression for " + currCellId;


            string currentCellExp = dictOfCellsViaId[currCellId].Exp;
            txt.Text = currentCellExp;
            
            /*
            double valueToGiveToCell = Calculator.Evaluate(currentCellExp, dictOfCellsViaId);
            if (currentCellExp != "")
            {
                dgv.CurrentCell.Value = valueToGiveToCell;
            }
          */
           


            //MessageBox.Show(currentCellExp, "Expression", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private string convertColAndRowToCellID(int col, int row)
        {
            return convertColIndexToChar(col) + Convert.ToString(row + 1);
        }

        private void CreateDataGrid(int rows, int cols)
        {
            for (int col = 0; col < cols; col++)
            {
                DataGridViewColumn vColumn = new DataGridViewColumn();

                for (int row = 0; row < rows; row++)
                {
                    MyCell tmp = new MyCell();
                    string tmp_name = convertColAndRowToCellID(col, row);
                    tmp.Name = tmp_name;
               
                    dictOfCellsViaId.Add(tmp_name, tmp);

                   // MessageBox.Show(tmp_name, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                MyCell cell = new MyCell();
              

                vColumn.CellTemplate = cell;

               vColumn.HeaderText = convertColIndexToChar(col);
               vColumn.Name = convertColIndexToChar(col);

                dataGridView1.Columns.Add(vColumn);
            }

            DataGridViewRow vRow = new DataGridViewRow();
            dataGridView1.Rows.Add(vRow);
            for (int row = 0; row < rows; row++)
            {
                dataGridView1.Rows.Add();
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


        private void dataGridView_CellEndEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                Console.WriteLine("BEGINNING");
                currRow = dataGridView1.CurrentCell.RowIndex;
                currCol = dataGridView1.CurrentCell.ColumnIndex;

                string cell_n = (char)(currCol + 65) + (currRow + 1).ToString();
                dataGridView1[currCol, currRow].Value = dictOfCellsViaId[cell_n].Exp;
                expressionTextBox.Text = "clicked";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public MainForm()
        {
            InitializeComponent();
            CreateDataGrid(8, 8);

            SetRowNum(dataGridView1);
          


    }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            addRow(dataGridView1);
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            addColumn(dataGridView1);
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            if (!validateIfCurrentCellPresent(dataGridView1)) return;

            showCurrentCellExpt(dataGridView1, expressionTextBox);

        }

        private void dataGridview1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!validateIfCurrentCellPresent(dataGridView1)) return;

            showCurrentCellExpt(dataGridView1, expressionTextBox);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (!validateIfCurrentCellPresent(dataGridView1)) return;

            showCurrentCellId(dataGridView1);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show(Calculator.Evaluate(expressionTextBox.Text, dictOfCellsViaId).ToString(), "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error); 
        }


        private void expressionTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void submitExprBtn_Click(object sender, EventArgs e)
        {
            if (currCellId == "")
            {
                MessageBox.Show("Спочатку виберіть клітинку!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Set expression and clear textBox
            dictOfCellsViaId[currCellId].Exp = expressionTextBox.Text;
            dictOfCellsViaId[currCellId].ValueDouble = Calculator.Evaluate(expressionTextBox.Text, dictOfCellsViaId);


            Debug.WriteLine("CurrentCellID: {0}, value: {1}", currCellId, dictOfCellsViaId[currCellId].ValueDouble);
            Debug.WriteLine(dataGridView1.CurrentCell.ToString());

            string currentCellExp = dictOfCellsViaId[currCellId].Exp;
            labelForExprInp.Text = "Expression for " + currCellId;

            double valueToGiveToCell = Calculator.Evaluate(currentCellExp, dictOfCellsViaId);

            if (currentCellExp != "")
            {
                dataGridView1.CurrentCell.Value = valueToGiveToCell;
            }

            //expressionTextBox.Text = "";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void saveDGV(string path)
        {
            
            
        }
    }
}
