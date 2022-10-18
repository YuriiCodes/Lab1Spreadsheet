using Antlr4.Runtime.Misc;
using LabCalculator;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab1Spreadsheet
{
    class LabCalculatorVisitor : LabCalculatorBaseVisitor<double>
    {
        //таблиця ідентифікаторів (тут для прикладу)
        //в лабораторній роботі заміните на свою!!!!
        public LabCalculatorVisitor(Dictionary<string, MyCell> cells)
        {
            this.cells = cells;
        }
        private Dictionary<string, MyCell> cells;

        public override double VisitCompileUnit(LabCalculatorParser.CompileUnitContext context)
        {
            return Visit(context.expression());
        }
        public override double VisitNumberExpr(LabCalculatorParser.NumberExprContext context)
        {
            var result = double.Parse(context.GetText());
            Debug.WriteLine(result);

            return result;
        }


        //IdentifierExpr
        public override double VisitIdentifierExpr(LabCalculatorParser.IdentifierExprContext context)
        {
            var result = context.GetText();
            MyCell cell;
            //видобути значення змінної з таблиці
            if (cells.TryGetValue(result.ToString(), out cell))
            {
                return cell.ValueDouble;
            }
            else
            {
                return 0.0;
            }
        }

        public override double VisitParenthesizedExpr(LabCalculatorParser.ParenthesizedExprContext context)
        {
            return Visit(context.expression());
        }

        public override double VisitExponentialExpr(LabCalculatorParser.ExponentialExprContext context)
        {
            var left = WalkLeft(context);
            var right = WalkRight(context);
            Debug.WriteLine("{0} ^ {1}", left, right);
            return System.Math.Pow(left, right);
        }

        public override double VisitAdditiveExpr(LabCalculatorParser.AdditiveExprContext context)
        {
            var left = WalkLeft(context);
            var right = WalkRight(context);
            if (context.operatorToken.Type == LabCalculatorLexer.ADD)
            {
                Debug.WriteLine("{0} + {1}", left, right);
                return left + right;
            }
            else //LabCalculatorLexer.SUBTRACT
            {
                Debug.WriteLine("{0} - {1}", left, right);
                return left - right;
            }
        }

        public override double VisitRelationalExpr( LabCalculatorParser.RelationalExprContext context)
        {
            var left = WalkLeft(context);
            var right = WalkRight(context);

            if (context.operatorToken.Type == LabCalculatorLexer.LESSTHAN)
            {
                Debug.WriteLine("{0} < {1}", left, right);
                if (left < right)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            else if(context.operatorToken.Type == LabCalculatorLexer.LESSTHANEQUAL)
            {
                Debug.WriteLine("{0} <= {1}", left, right);
                if (left <= right)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            else if (context.operatorToken.Type == LabCalculatorLexer.GREATERTHAN)
            {
                Debug.WriteLine("{0} > {1}", left, right);
                if (left > right)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            else if (context.operatorToken.Type == LabCalculatorLexer.GREATERTHANEQUAL)
            {
                Debug.WriteLine("{0} => {1}", left, right);
                if (left >= right)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            else if (context.operatorToken.Type == LabCalculatorLexer.EQUAL)
            {
                Debug.WriteLine("{0} == {1}", left, right);
                if (left == right)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            // a != b
            else if (context.operatorToken.Type == LabCalculatorLexer.NOTEQUAL)
            {
                Debug.WriteLine("{0} != {1}", left, right);
                if (left != right)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }

            else
            {
                return 0;
            }
        }

        public override double VisitLogicalExpr(LabCalculatorParser.LogicalExprContext context)
        {
            var left = WalkLeft(context);
            var right = WalkRight(context);

            if (context.operatorToken.Type == LabCalculatorLexer.AND)
            {
                Debug.WriteLine("{0} && {1}", left, right);
                if (left != 0 && right != 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            else if (context.operatorToken.Type == LabCalculatorLexer.OR)
            {
                Debug.WriteLine("{0} || {1}", left, right);
                if (left != 0 || right != 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }

        }

        public override double VisitMultiplicativeExpr(LabCalculatorParser.MultiplicativeExprContext context)
        {
            var left = WalkLeft(context);
            var right = WalkRight(context);
            if (context.operatorToken.Type == LabCalculatorLexer.MULTIPLY)
            {
                Debug.WriteLine("{0} * {1}", left, right);
                return left * right;
            }
            else //LabCalculatorLexer.DIVIDE
            {
                Debug.WriteLine("{0} / {1}", left, right);
                return left / right;
            }
        }

        public override double VisitModDivExpr(LabCalculatorParser.ModDivExprContext context)
        {
            var left = WalkLeft(context);
            var right = WalkRight(context);

            return context.operatorToken.Type == LabCalculatorLexer.MOD
                ? left % right
                : (int)left / (int)right;
        }

        public override double VisitMminExpr(LabCalculatorParser.MminExprContext context)
        {
            double minValue = Double.PositiveInfinity;

            foreach(var child in context.paramlist.children.OfType<LabCalculatorParser.ExpressionContext>())
            {
                double childValue = this.Visit(child);
                if (childValue < minValue)
                {
                    minValue = childValue;
                }
            }
            return minValue;
        }

        public override double VisitMmaxExpr(LabCalculatorParser.MmaxExprContext context)
        {
            double maxValue = Double.NegativeInfinity;

            foreach (var child in context.paramlist.children.OfType<LabCalculatorParser.ExpressionContext>())
            {
                double childValue = this.Visit(child);
                if (childValue > maxValue)
                {
                    maxValue = childValue;
                }
            }
            return maxValue;
        }
        public override double VisitIncDecExpr( LabCalculatorParser.IncDecExprContext context)
        {
            double res = 0;


            var child = context.paramlist.children.OfType<LabCalculatorParser.ExpressionContext>().First();
            double childValue = this.Visit(child);
            if (context.operatorToken.Type == LabCalculatorLexer.INC)
            {
                return  childValue + 1;
            }
            else
            {
                return childValue - 1;
            }
        }

        public override double VisitLogicalNotExpr(LabCalculatorParser.LogicalNotExprContext context)
        {

            var child = context.paramlist.children.OfType<LabCalculatorParser.ExpressionContext>().First();
            double childValue = this.Visit(child);
            if (childValue != 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
        private double WalkLeft(LabCalculatorParser.ExpressionContext context)
        {
            return Visit(context.GetRuleContext<LabCalculatorParser.ExpressionContext>(0));
        }
        private double WalkRight(LabCalculatorParser.ExpressionContext context)
        {
            return Visit(context.GetRuleContext<LabCalculatorParser.ExpressionContext>(1));
        }
    }
}
