using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static System.Net.Mime.MediaTypeNames;

namespace Lab1Spreadsheet
{
    public partial class MainForm : Form
    {

        private string rows = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private string cols = "1234567890";

        // When formula for C1 is A1 + B1, ralyOn will be like ralayOn["C1"] = ["A1", "B1"]. We will need this info for further re-rendering cells.
        private Dictionary<string, List<string>> relayOn = new Dictionary<string, List<string>>();

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

        private int getCellRowFromCellId(string cellId)
        {
            int startIndex = cellId.IndexOfAny("0123456789".ToCharArray());
            int row = Int32.Parse(cellId.Substring(startIndex)) - 1;
            return row;
        }

        private static int getCellColFromCellId(string cellId)
        {
            int startIndex = cellId.IndexOfAny("0123456789".ToCharArray());
            string column = cellId.Substring(0, startIndex);

            int res = Convert.ToChar(column) - 'A';
            return res;
        }


        // This function is called when user clicks on cell.
        public void showCurrentCellExpt(DataGridView dgv, TextBox txt) {
            Debug.WriteLine("Clicked on Cell");

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
                dataGridView.Rows[i].HeaderCell.Value = (i + 1).ToString();
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
            MessageBox.Show(dataGridView1.CurrentCell.ToString());

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

        private List<string> getCellsValueIsDependentOn(string formula)
        {

            
            List<string> res = new List<string>();
            // regex comments in this style requires RegexOptions.IgnorePatternWhitespace
            string rxCellPattern = @"(?<![$])       # match if prefix is absent: $ symbol (prevents matching $A1 type of cells)
                                            # (if all you have is $A$1 type of references, and not $A1 types, this negative look-behind isn't needed)
                            \b              # word boundary (prevents matching Excel functions with a similar pattern to a cell)
                            (?<col>[A-Z]+)  # named capture group, match uppercase letter at least once
                                            # (change to [A-Za-z] if you have lowercase cells)
                            (?<row>\d+)     # named capture group, match a number at least once
                            \b              # word boundary
                            ";


            Regex rxCell = new Regex(rxCellPattern, RegexOptions.IgnorePatternWhitespace);


            if (rxCell.IsMatch(formula)) //B1^2
            {

                foreach (Match cell in rxCell.Matches(formula))
                {
                    // break if there is a recursion in the formula
                    if (cell.Value == currCellId) break;

                   
                    res.Add(cell.Value);
  
                    string dep = dictOfCellsViaId[cell.Value].Exp;

                    
                    

                    foreach (string newDep in getCellsValueIsDependentOn(dep))
                    {   
                        res.Add(newDep);
                    }
                }
            }
            return res;
        }
       

        private void reRenderCell(string cellId)
        {
            Debug.WriteLine("RERENDERING " + cellId);
            string exprressionOfCellToRerender = dictOfCellsViaId[cellId].Exp;

            //1: Re-calculate value based on expression
            double new_val = Calculator.Evaluate(exprressionOfCellToRerender, dictOfCellsViaId);

            //2. Update dict of cells values
            dictOfCellsViaId[cellId].Value = Convert.ToString(new_val);
            dictOfCellsViaId[cellId].ValueDouble = new_val;

            //3. Create functions to get cell and row from cellId
            int row_of_cell_to_be_rerendered = getCellRowFromCellId(cellId);
            int col_of_cell_to_be_rerendered = getCellColFromCellId(cellId);
            //4. Update cell view

            dataGridView1[col_of_cell_to_be_rerendered, row_of_cell_to_be_rerendered].Value = new_val;
        }
        // a helper function to deal with recursion
        private void validateRecursion()
        {
            MessageBox.Show("Recursion detected! State of table will be reset to the one before you added the recursion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            // clear expression and value of cell
            dictOfCellsViaId[currCellId].Exp = "";
            dictOfCellsViaId[currCellId].Value = "";
            dictOfCellsViaId[currCellId].ValueDouble = 0;
            // clear cell view
            dataGridView1[getCellColFromCellId(currCellId), getCellRowFromCellId(currCellId)].Value = "";

            // clear text box
            expressionTextBox.Text = "";
            return;
        }
        private void updateDependencyDict(string expr)
        {
            List<string> nowRelayOn = getCellsValueIsDependentOn(expr);
            
            List<string> tmp = new List<string>();
            if (relayOn.TryGetValue(currCellId, out tmp))
            {
                foreach (string cell in nowRelayOn)
                {

                    if (!tmp.Contains(cell))
                    {
                        // check for recursion, if there is recursion created - show error
                        if (relayOn.ContainsKey(cell) && relayOn[cell].Contains(currCellId))
                        {
                            validateRecursion();
                        }
                        else
                        {
                            relayOn[currCellId].Add(cell);
                            dictOfCellsViaId[currCellId].dependentOn.Add(dictOfCellsViaId[cell]);
                        }
                       
                    }
                }
            }
            else
            {
                // check for recursion, if there is recursion created - show error
                foreach (string cell in nowRelayOn)
                {
                    if (relayOn.ContainsKey(cell) && relayOn[cell].Contains(currCellId))
                    {
                        validateRecursion();
                    }
                }
                relayOn.Add(currCellId, nowRelayOn);
                foreach (string i in nowRelayOn)
                {
                    // check for recursion, if there is recursion created - show error
                    if (relayOn.ContainsKey(i) && relayOn[i].Contains(currCellId))
                    {
                        validateRecursion(); 
                    } else
                    {
                        dictOfCellsViaId[currCellId].dependentOn.Add(dictOfCellsViaId[i]);
                    }
                    
                }
            }

            // Check dependencies
            if (nowRelayOn.Count == 0)
            {
                Debug.WriteLine("NO DEPENDENCIES");
            }
            else
            {
                Debug.WriteLine("dependent ");
                foreach (string cell in nowRelayOn)
                {
                    Debug.WriteLine("CELL DEPENDENT ON:");
                    Debug.WriteLine(cell);
                }
            }

        }

        /*
                 * Each MyCell has a public field dependentOn - a list of cells that this function is dependent on. Code below check for recusrion recursively, returning true if there is recursion, and false  if not: */
        private bool isRecursive(MyCell currentCell, MyCell initialCell)
        {
            {
                if (currentCell.dependentOn.Count == 0)
                {
                    return false;
                }
                else
                {
                    foreach (MyCell cell in currentCell.dependentOn)
                    {
                        if (cell == initialCell)
                        {
                            return true;
                        }
                        else
                        {
                            if (isRecursive(cell, initialCell))
                            {
                                return true;
                            }
                        }
                    }
                }
                return false;
            }
        }



        // TODO: REMOVE MAGIC BUTTON ANTIPATTERN FROM HERE
        private void submitExprBtn_Click(object sender, EventArgs e)
        {
            if (currCellId == "")
            {
                MessageBox.Show("Спочатку виберіть клітинку!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

           
          

           dictOfCellsViaId[currCellId].Exp = expressionTextBox.Text;




            if (isRecursive(dictOfCellsViaId[currCellId], dictOfCellsViaId[currCellId]))
            {
                MessageBox.Show("Циклічна залежність!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            updateDependencyDict(expressionTextBox.Text);
          
           
            labelForExprInp.Text = "Expression for " + currCellId;

            reRenderCell(currCellId);

            foreach (KeyValuePair<string, List<string>> entry in relayOn)
            {
                foreach (string cellId in entry.Value)
                {
                    // we are editing a cell, that other cell relays on => we have to re-render this cell
                    if (cellId == currCellId)
                    {
                        reRenderCell(entry.Key);
                    }
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var window = MessageBox.Show(
           "Close the window?",
           "Are you sure?",
           MessageBoxButtons.YesNo);


            e.Cancel = (window == DialogResult.No);
        }
        private void saveTableToXml(string path)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "\t";
            using (XmlWriter writer = XmlWriter.Create(path, settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Table");
                foreach (KeyValuePair<string, MyCell> entry in dictOfCellsViaId)
                {
                    writer.WriteStartElement("Cell");
                    writer.WriteElementString("Id", entry.Key);
                    writer.WriteElementString("Value", entry.Value.Value);
                    writer.WriteElementString("ValueDouble", entry.Value.ValueDouble.ToString());
                    writer.WriteElementString("Expression", entry.Value.Exp);
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            // save file in xml format
            saveFileDialog1.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
            saveFileDialog1.Title = "Save table File";
            saveFileDialog1.ShowDialog();

            // If the file name is not an empty string open it for saving.
            if (saveFileDialog1.FileName != "")
            {
                // save table to xml file
                saveTableToXml(saveFileDialog1.FileName);
            } else
            {
                {
                    MessageBox.Show("Ви не вибрали файл!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }



        }

        private void loadTableFromXml(string path)
        {

            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlNodeList nodes = doc.SelectNodes("/Table/Cell");
            foreach (XmlNode node in nodes)
            {
                string id = node.SelectSingleNode("Id").InnerText;
                string value = node.SelectSingleNode("Value").InnerText;
                //parse valueDOuble
                double valueDouble = node.SelectSingleNode("ValueDouble").InnerText == "" ? 0 : double.Parse(node.SelectSingleNode("ValueDouble").InnerText);
                string expression = node.SelectSingleNode("Expression").InnerText;

                //check if dictOfCellsViaId[id] is valid cell,  if yes - add values, if no - create and append values.
                if (dictOfCellsViaId.ContainsKey(id))
                {
                    dictOfCellsViaId[id].Value = value;
                    dictOfCellsViaId[id].ValueDouble = valueDouble;
                    dictOfCellsViaId[id].Exp = expression;
                }
                else
                {
                    MyCell tmp = new MyCell();
                    tmp.Value = value;
                    tmp.ValueDouble = valueDouble;
                    tmp.Exp = expression;
                    dictOfCellsViaId.Add(id, tmp);
                }
               
                reRenderCell(id);
            }
            

        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // load the table from xml file
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
            openFileDialog1.Title = "Open table File";
            openFileDialog1.ShowDialog();

            if (openFileDialog1.FileName != "")
            {
                // load table from xml file
                loadTableFromXml(openFileDialog1.FileName);
            }
            else
            {
                {
                    MessageBox.Show("Ви не вибрали файл!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void saveDGV(string path)
        {
            
            
        }
    }
}
