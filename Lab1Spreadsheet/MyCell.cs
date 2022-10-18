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

            // all the calculations are performed via valDouble value.
            this.valDouble = 0.0;
            this.exp = "";
        }

        // A public name field, needed in case when we will want to work with each cell separate, and not by dictionary that stores cells by names.
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        // We have to keep value, so that we don't break Liskov Substitution principle in terms of DataGridViewTextBoxCell, however, we will yse valDouble for all the calculations.
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
