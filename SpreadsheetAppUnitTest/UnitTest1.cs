using Lab1Spreadsheet;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace SpreadsheetAppUnitTest
{
    [TestClass]
    public class UnitTest1
    {

        private Dictionary<string, MyCell> mockOfictOfCellsViaId = new Dictionary<string, MyCell>();

        //Add A1 = 10 to mockOfictOfCellsViaId and then test A1 to check if Calculator can work with cells
        [TestMethod]
        public void Test_Calculator_with_cells()
        {
            MyCell cellA1 = new MyCell();
            cellA1.Name = "A1";
            cellA1.Value = "10";
            cellA1.ValueDouble = 10;
            cellA1.Exp = "10";

            mockOfictOfCellsViaId.Add("A1", cellA1);

            string expr = "A1";
            double res = Lab1Spreadsheet.Calculator.Evaluate(expr, mockOfictOfCellsViaId);
            Assert.AreEqual(res, 10);
        }

        // Test Calculator to perform multiplication: A1 = 10, A2 = 5, A3 = A1 * A2
        [TestMethod]
        public void Test_Calculator_with_cells_multiplication()
        {
            MyCell cellA1 = new MyCell();
            cellA1.Name = "A1";
            cellA1.Value = "10";
            cellA1.ValueDouble = 10;
            cellA1.Exp = "10";

            MyCell cellA2 = new MyCell();
            cellA2.Name = "A2";
            cellA2.Value = "5";
            cellA2.ValueDouble = 5;
            cellA2.Exp = "5";

            MyCell cellA3 = new MyCell();
            cellA3.Name = "A3";
            cellA3.Value = "A1 * A2";
            cellA3.ValueDouble = 50;
            cellA3.Exp = "A1 * A2";

            mockOfictOfCellsViaId.Add("A1", cellA1);
            mockOfictOfCellsViaId.Add("A2", cellA2);
            mockOfictOfCellsViaId.Add("A3", cellA3);

            string expr = "A3";
            double res = Lab1Spreadsheet.Calculator.Evaluate(expr, mockOfictOfCellsViaId);
            Assert.AreEqual(res, 50);
        }

        // Test Calculator to perform addition: A1 = 10, A2 = 5, A3 = A1 + A2
        [TestMethod]
        public void Test_Calculator_with_cells_addition()
        {
            MyCell cellA1 = new MyCell();
            cellA1.Name = "A1";
            cellA1.Value = "10";
            cellA1.ValueDouble = 10;
            cellA1.Exp = "10";

            MyCell cellA2 = new MyCell();
            cellA2.Name = "A2";
            cellA2.Value = "5";
            cellA2.ValueDouble = 5;
            cellA2.Exp = "5";

            MyCell cellA3 = new MyCell();
            cellA3.Name = "A3";
            cellA3.Value = "A1 + A2";
            cellA3.ValueDouble = 15;
            cellA3.Exp = "A1 + A2";

            mockOfictOfCellsViaId.Add("A1", cellA1);
            mockOfictOfCellsViaId.Add("A2", cellA2);
            mockOfictOfCellsViaId.Add("A3", cellA3);

            string expr = "A3";
            double res = Lab1Spreadsheet.Calculator.Evaluate(expr, mockOfictOfCellsViaId);
            Assert.AreEqual(res, 15);
        }

        // Test Calculator to perform subtraction: A1 = 10, A2 = 5, A3 = A1 - A2
        [TestMethod]
        public void Test_Calculator_with_cells_subtraction()
        {
            MyCell cellA1 = new MyCell();
            cellA1.Name = "A1";
            cellA1.Value = "10";
            cellA1.ValueDouble = 10;
            cellA1.Exp = "10";

            MyCell cellA2 = new MyCell();
            cellA2.Name = "A2";
            cellA2.Value = "5";
            cellA2.ValueDouble = 5;
            cellA2.Exp = "5";

            MyCell cellA3 = new MyCell();
            cellA3.Name = "A3";
            cellA3.Value = "A1 - A2";
            cellA3.ValueDouble = 5;
            cellA3.Exp = "A1 - A2";

            mockOfictOfCellsViaId.Add("A1", cellA1);
            mockOfictOfCellsViaId.Add("A2", cellA2);
            mockOfictOfCellsViaId.Add("A3", cellA3);

            string expr = "A3";
            double res = Lab1Spreadsheet.Calculator.Evaluate(expr, mockOfictOfCellsViaId);
            Assert.AreEqual(res, 5);
        }

        // Test Calculator to perform raising to power: A1 = 10, A2 = 5, A3 = A1 ^ A2
        [TestMethod]
        public void Test_Calculator_with_cells_raising_to_power()
        {
            MyCell cellA1 = new MyCell();
            cellA1.Name = "A1";
            cellA1.Value = "10";
            cellA1.ValueDouble = 10;
            cellA1.Exp = "10";

            MyCell cellA2 = new MyCell();
            cellA2.Name = "A2";
            cellA2.Value = "5";
            cellA2.ValueDouble = 5;
            cellA2.Exp = "5";

            MyCell cellA3 = new MyCell();
            cellA3.Name = "A3";
            cellA3.Value = "A1 ^ A2";
            cellA3.ValueDouble = 100000;
            cellA3.Exp = "A1 ^ A2";

            mockOfictOfCellsViaId.Add("A1", cellA1);
            mockOfictOfCellsViaId.Add("A2", cellA2);
            mockOfictOfCellsViaId.Add("A3", cellA3);

            string expr = "A3";
            double res = Lab1Spreadsheet.Calculator.Evaluate(expr, mockOfictOfCellsViaId);
            Assert.AreEqual(res, 100000);
        }

        // Test Calulator to perform division: A1 = 10, A2 = 5, A3 = A1 / A2
        [TestMethod]
        public void Test_Calculator_with_cells_division()
        {
            MyCell cellA1 = new MyCell();
            cellA1.Name = "A1";
            cellA1.Value = "10";
            cellA1.ValueDouble = 10;
            cellA1.Exp = "10";

            MyCell cellA2 = new MyCell();
            cellA2.Name = "A2";
            cellA2.Value = "5";
            cellA2.ValueDouble = 5;
            cellA2.Exp = "5";

            MyCell cellA3 = new MyCell();
            cellA3.Name = "A3";
            cellA3.Value = "A1 / A2";
            cellA3.ValueDouble = 2;
            cellA3.Exp = "A1 / A2";

            mockOfictOfCellsViaId.Add("A1", cellA1);
            mockOfictOfCellsViaId.Add("A2", cellA2);
            mockOfictOfCellsViaId.Add("A3", cellA3);

            string expr = "A3";
            double res = Lab1Spreadsheet.Calculator.Evaluate(expr, mockOfictOfCellsViaId);
            Assert.AreEqual(res, 2);
        }

        // Test Calculator to perform equality check: A1 = 10, A2 = 5, A3 = A1 == A2
        [TestMethod]
        public void Test_Calculator_with_cells_equality_check()
        {
            MyCell cellA1 = new MyCell();
            cellA1.Name = "A1";
            cellA1.Value = "10";
            cellA1.ValueDouble = 10;
            cellA1.Exp = "10";

            MyCell cellA2 = new MyCell();
            cellA2.Name = "A2";
            cellA2.Value = "5";
            cellA2.ValueDouble = 5;
            cellA2.Exp = "5";

            MyCell cellA3 = new MyCell();
            cellA3.Name = "A3";
            cellA3.Exp = "A1 == A2";

            mockOfictOfCellsViaId.Add("A1", cellA1);
            mockOfictOfCellsViaId.Add("A2", cellA2);
            mockOfictOfCellsViaId.Add("A3", cellA3);

            string expr = "A3";
            double res = Lab1Spreadsheet.Calculator.Evaluate(expr, mockOfictOfCellsViaId);
            Assert.AreEqual(res, 0);
        }

        // Test Calculator to perform not equality check: A1 = 10, A2 = 5, A3 = A1 != A2
        [TestMethod]
        public void Test_Calculator_with_cells_not_equality_check()
        {
            MyCell cellA1 = new MyCell();
            cellA1.Name = "A1";
            cellA1.Value = "10";
            cellA1.ValueDouble = 10;
            cellA1.Exp = "10";

            MyCell cellA2 = new MyCell();
            cellA2.Name = "A2";
            cellA2.Value = "5";
            cellA2.ValueDouble = 5;
            cellA2.Exp = "5";

            MyCell cellA3 = new MyCell();
            cellA3.Name = "A3";
            cellA3.Exp = "A1 != A2";

            mockOfictOfCellsViaId.Add("A1", cellA1);
            mockOfictOfCellsViaId.Add("A2", cellA2);
            mockOfictOfCellsViaId.Add("A3", cellA3);

            string expr = "A3";
            double res = Lab1Spreadsheet.Calculator.Evaluate(expr, mockOfictOfCellsViaId);
            Assert.AreEqual(res, 0);
        }

        // Test Calculator to perform less than check: A1 = 10, A2 = 5, A3 = A1 < A2
        [TestMethod]
        public void Test_Calculator_with_cells_less_than_check()
        {
            MyCell cellA1 = new MyCell();
            cellA1.Name = "A1";
            cellA1.Value = "10";
            cellA1.ValueDouble = 10;
            cellA1.Exp = "10";

            MyCell cellA2 = new MyCell();
            cellA2.Name = "A2";
            cellA2.Value = "5";
            cellA2.ValueDouble = 5;
            cellA2.Exp = "5";

            MyCell cellA3 = new MyCell();
            cellA3.Name = "A3";
            cellA3.Exp = "A1 < A2";

            mockOfictOfCellsViaId.Add("A1", cellA1);
            mockOfictOfCellsViaId.Add("A2", cellA2);
            mockOfictOfCellsViaId.Add("A3", cellA3);

            string expr = "A3";
            double res = Lab1Spreadsheet.Calculator.Evaluate(expr, mockOfictOfCellsViaId);
            Assert.AreEqual(res, 0);
        }

        // Test Calculator to perform greater than check: A1 = 10, A2 = 5, A3 = A1 > A2
        [TestMethod]
        public void Test_Calculator_with_cells_greater_than_check()
        {
            MyCell cellA1 = new MyCell();
            cellA1.Name = "A1";
            cellA1.Value = "10";
            cellA1.ValueDouble = 10;
            cellA1.Exp = "10";

            MyCell cellA2 = new MyCell();
            cellA2.Name = "A2";
            cellA2.Value = "5";
            cellA2.ValueDouble = 5;
            cellA2.Exp = "5";

            MyCell cellA3 = new MyCell();
            cellA3.Name = "A3";
            cellA3.Exp = "A1 > A2";

            mockOfictOfCellsViaId.Add("A1", cellA1);
            mockOfictOfCellsViaId.Add("A2", cellA2);
            mockOfictOfCellsViaId.Add("A3", cellA3);

            string expr = "A3";
            double res = Lab1Spreadsheet.Calculator.Evaluate(expr, mockOfictOfCellsViaId);
            Assert.AreEqual(res, 0);
        }

        // Test Calculator to perform less than or equal to check: A1 = 10, A2 = 5, A3 = A1 <= A2
        [TestMethod]
        public void Test_Calculator_with_cells_less_than_or_equal_to_check()
        {
            MyCell cellA1 = new MyCell();
            cellA1.Name = "A1";
            cellA1.Value = "10";
            cellA1.ValueDouble = 10;
            cellA1.Exp = "10";

            MyCell cellA2 = new MyCell();
            cellA2.Name = "A2";
            cellA2.Value = "5";
            cellA2.ValueDouble = 5;
            cellA2.Exp = "5";

            MyCell cellA3 = new MyCell();
            cellA3.Name = "A3";
            cellA3.Exp = "A1 <= A2";

            mockOfictOfCellsViaId.Add("A1", cellA1);
            mockOfictOfCellsViaId.Add("A2", cellA2);
            mockOfictOfCellsViaId.Add("A3", cellA3);

            string expr = "A3";
            double res = Lab1Spreadsheet.Calculator.Evaluate(expr, mockOfictOfCellsViaId);
            Assert.AreEqual(res, 0);
        }

        // Test Calculator to perform greater than or equal to check: A1 = 10, A2 = 5, A3 = A1 >= A2
        [TestMethod]
        public void Test_Calculator_with_cells_greater_than_or_equal_to_check()
        {
            MyCell cellA1 = new MyCell();
            cellA1.Name = "A1";
            cellA1.Value = "10";
            cellA1.ValueDouble = 10;
            cellA1.Exp = "10";

            MyCell cellA2 = new MyCell();
            cellA2.Name = "A2";
            cellA2.Value = "5";
            cellA2.ValueDouble = 5;
            cellA2.Exp = "5";

            MyCell cellA3 = new MyCell();
            cellA3.Name = "A3";
            cellA3.Exp = "A1 >= A2";

            mockOfictOfCellsViaId.Add("A1", cellA1);
            mockOfictOfCellsViaId.Add("A2", cellA2);
            mockOfictOfCellsViaId.Add("A3", cellA3);

            string expr = "A3";
            double res = Lab1Spreadsheet.Calculator.Evaluate(expr, mockOfictOfCellsViaId);
            Assert.AreEqual(res, 0);
        }

        // Test Calculator to perform binary AND operation: A1 = 1, A2 = 0, A3 = A1 & A2
        [TestMethod]
        public void Test_Calculator_with_cells_binary_AND_operation()
        {
            MyCell cellA1 = new MyCell();
            cellA1.Name = "A1";
            cellA1.Value = "1";
            cellA1.ValueDouble = 1;
            cellA1.Exp = "1";

            MyCell cellA2 = new MyCell();
            cellA2.Name = "A2";
            cellA2.Value = "0";
            cellA2.ValueDouble = 0;
            cellA2.Exp = "0";

            MyCell cellA3 = new MyCell();
            cellA3.Name = "A3";
            cellA3.Exp = "A1 & A2";

            mockOfictOfCellsViaId.Add("A1", cellA1);
            mockOfictOfCellsViaId.Add("A2", cellA2);
            mockOfictOfCellsViaId.Add("A3", cellA3);

            string expr = "A3";
            double res = Lab1Spreadsheet.Calculator.Evaluate(expr, mockOfictOfCellsViaId);
            Assert.AreEqual(res, 0);
        }

        // Test Calculator to perform binary OR opearion: A1 = 1, A2 = 0, A3 = A1 | A2
        [TestMethod]
        public void Test_Calculator_with_cells_binary_OR_operation()
        {
            MyCell cellA1 = new MyCell();
            cellA1.Name = "A1";
            cellA1.Value = "1";
            cellA1.ValueDouble = 1;
            cellA1.Exp = "1";

            MyCell cellA2 = new MyCell();
            cellA2.Name = "A2";
            cellA2.Value = "0";
            cellA2.ValueDouble = 0;
            cellA2.Exp = "0";



            mockOfictOfCellsViaId.Add("A1", cellA1);
            mockOfictOfCellsViaId.Add("A2", cellA2);

            double res = Lab1Spreadsheet.Calculator.Evaluate("A1 || A2", mockOfictOfCellsViaId);
            Assert.AreEqual(res, 1);
        }

        // Test Calculator to perform mod operation: A1 = 10, A2 = 5, A3 = A1 % A2
        [TestMethod]
        public void Test_Calculator_with_cells_mod_operation()
        {
            MyCell cellA1 = new MyCell();
            cellA1.Name = "A1";
            cellA1.Value = "10";
            cellA1.ValueDouble = 10;
            cellA1.Exp = "10";

            MyCell cellA2 = new MyCell();
            cellA2.Name = "A2";
            cellA2.Value = "5";
            cellA2.ValueDouble = 5;
            cellA2.Exp = "5";

            MyCell cellA3 = new MyCell();
            cellA3.Name = "A3";
            cellA3.Exp = "A1 % A2";

            mockOfictOfCellsViaId.Add("A1", cellA1);
            mockOfictOfCellsViaId.Add("A2", cellA2);
            mockOfictOfCellsViaId.Add("A3", cellA3);

            string expr = "A3";
            double res = Lab1Spreadsheet.Calculator.Evaluate(expr, mockOfictOfCellsViaId);
            Assert.AreEqual(res, 0);
        }

        // Test Calculator to perform unary NOT operation: A1 = 1, A2 = !A1
        [TestMethod]
        public void Test_Calculator_with_cells_unary_NOT_operation()
        {
            MyCell cellA1 = new MyCell();
            cellA1.Name = "A1";
            cellA1.Value = "1";
            cellA1.ValueDouble = 1;
            cellA1.Exp = "1";

            MyCell cellA2 = new MyCell();
            cellA2.Name = "A2";
            cellA2.Exp = "!A1";

            mockOfictOfCellsViaId.Add("A1", cellA1);
            mockOfictOfCellsViaId.Add("A2", cellA2);

            string expr = "A2";
            double res = Lab1Spreadsheet.Calculator.Evaluate(expr, mockOfictOfCellsViaId);
            Assert.AreEqual(res, 0);
        }


        // Test Calculator to perform increment operation: A1 = 1, A2 = inc(A1)
        [TestMethod]
        public void Test_Calculator_with_cells_increment_operation()
        {
            MyCell cellA1 = new MyCell();
            cellA1.Name = "A1";
            cellA1.Value = "1";
            cellA1.ValueDouble = 1;
            cellA1.Exp = "1";

            mockOfictOfCellsViaId.Add("A1", cellA1);


            string expr = "inc(A1)";
            double res = Lab1Spreadsheet.Calculator.Evaluate(expr, mockOfictOfCellsViaId);
            Assert.AreEqual(res, 2);
        }

        // Test Calculator to perform decrement opearation: A1 = 1, A2 = dec(A1);
        [TestMethod]
        public void Test_Calculator_with_cells_decrement_operation()
        {
            MyCell cellA1 = new MyCell();
            cellA1.Name = "A1";
            cellA1.Value = "1";
            cellA1.ValueDouble = 1;
            cellA1.Exp = "1";



            mockOfictOfCellsViaId.Add("A1", cellA1);

            string expr = "dec(A1)";
            double res = Lab1Spreadsheet.Calculator.Evaluate(expr, mockOfictOfCellsViaId);
            Assert.AreEqual(res, 0);
        }

        // Test Calculator to perform mmax operation: A1 = 1, A2 = 2, A3 = 3, A4 = mmax(A1, A2, A3)
        [TestMethod]
        public void Test_Calculator_with_cells_mmax_operation()
        {
            MyCell cellA1 = new MyCell();
            cellA1.Name = "A1";
            cellA1.Value = "1";
            cellA1.ValueDouble = 1;
            cellA1.Exp = "1";

            MyCell cellA2 = new MyCell();
            cellA2.Name = "A2";
            cellA2.Value = "2";
            cellA2.ValueDouble = 2;
            cellA2.Exp = "2";

            MyCell cellA3 = new MyCell();
            cellA3.Name = "A3";
            cellA3.Value = "3";
            cellA3.ValueDouble = 3;
            cellA3.Exp = "3";


            mockOfictOfCellsViaId.Add("A1", cellA1);
            mockOfictOfCellsViaId.Add("A2", cellA2);
            mockOfictOfCellsViaId.Add("A3", cellA3);


            string expr = "mmax(A1, A2, A3)";
            double res = Lab1Spreadsheet.Calculator.Evaluate(expr, mockOfictOfCellsViaId);
            Assert.AreEqual(res, 3);
        }

        // Test Calculator to perform mmin operation: A1 = 1, A2 = 2, A3 = 3, A4 = mmin(A1, A2, A3)
        [TestMethod]
        public void Test_Calculator_with_cells_mmin_operation()
        {
            MyCell cellA1 = new MyCell();
            cellA1.Name = "A1";
            cellA1.Value = "1";
            cellA1.ValueDouble = 1;
            cellA1.Exp = "1";

            MyCell cellA2 = new MyCell();
            cellA2.Name = "A2";
            cellA2.Value = "2";
            cellA2.ValueDouble = 2;
            cellA2.Exp = "2";


            mockOfictOfCellsViaId.Add("A1", cellA1);
            mockOfictOfCellsViaId.Add("A2", cellA2);


            string expr = "mmin(A1, A2)";
            double res = Lab1Spreadsheet.Calculator.Evaluate(expr, mockOfictOfCellsViaId);
            Assert.AreEqual(res, 1);

        }
    }
}
