using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;
using LabCalculator;

namespace Lab1Spreadsheet
{
    class Calculator
    {
        public static double Evaluate(string expression)
        {
            var lexer = new LabCalculatorLexer(new AntlrInputStream(expression));
            lexer.RemoveErrorListeners();
            lexer.AddErrorListener(new ThrowExceptionErrorListener());
            var tokens = new CommonTokenStream(lexer);
            var parser = new LabCalculatorParser(tokens);
            var tree = parser.compileUnit();
            var visitor = new LabCalculatorVisitor();
            return visitor.Visit(tree);
        }
    }
}
