using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1Spreadsheet
{

    public class MyCell : DataGridViewTextBoxCell
    {
        private string name;
        private string val;
        private string exp;
        private double valDouble;
        public List<MyCell> dependentOn  = new List<MyCell>();

        public MyCell()
        {
            this.name = "";
            this.val = "";
            this.valDouble = 0.0;
            this.exp = "";
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Value
        {
            get { return val; }
            set { val = value; }
        }

        public double ValueDouble
        {
            get { return valDouble; }
            set { valDouble = value; }
        }

        public string Exp
        {
            get { return exp; }
            set { exp = value; }

        }

    }
}
