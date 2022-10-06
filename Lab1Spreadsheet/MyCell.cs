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
        private List<string> dependencies = new List<string>();

        public MyCell()
        {
            this.name = "";
            this.val = "";
            this.exp = "AMOGUS";
        }

        public string Name
        {
            get { return name; }
        }

        public string Value
        {
            get { return val; }
            set { val = value; }
        }

        public string Exp
        {
            get { return exp; }
            set { exp = value; }

        }

        public List<string> Dependencies
        { 
            get { return dependencies; } 
            set { dependencies = value; }
        }

    }
}
