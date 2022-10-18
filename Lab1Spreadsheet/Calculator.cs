using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;
using LabCalculator;

namespace Lab1Spreadsheet
{
    public class Calculator
    {
        public static double Evaluate(string expression, Dictionary<string, MyCell> cells)
        {
            var lexer = new LabCalculatorLexer(new AntlrInputStream(expression));
            lexer.RemoveErrorListeners();
            lexer.AddErrorListener(new ThrowExceptionErrorListener());

            var tokens = new CommonTokenStream(lexer);

            Debug.WriteLine("TOKENS:");
            Debug.WriteLine(tokens.GetText());
            var parser = new LabCalculatorParser(tokens);

            var tree = parser.compileUnit();

            var visitor = new LabCalculatorVisitor(cells);

            return visitor.Visit(tree);
        }
    }
}
