using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MathToGraph.Helper
{
    public static class EquationHelper
    {
        public static void ReadEquation()
        {
            {
                try
                {
                    string equation = "(a4234) * (3)  + 12432 + b123";
                    List<string> operands = FindOperands(expression: equation);

                    // Remove the numaric values
                    var variables = operands.Where(p => p.Any(char.IsLetter)).ToArray();

                    DataTable dt = new DataTable();
                    // create columns with type
                    dt.AddColumnsWithType(typeof(double), variables);

                    // add values 
                    // right now adding 10 random values
                    for (int i = 0; i < 10; i++)
                    {
                        DataRow dr = dt.NewRow(); //Creating a New Row  
                        for (int k = 0; k < variables.Length; k++)
                        {
                            dr[variables[k]] = (1 * i) + k;
                        }
                        dt.Rows.Add(dr); // Add the Row to the DataTable  
                    }

                    dt.CreateSolutionColumn(equation, typeof(double));

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }               
            }
        }

        public static void CreateSolutionColumn(this DataTable dt, string equation, Type type, string colName = "Total")
        {
            DataColumn column = new DataColumn();
            column.DataType = type;
            column.Expression = equation;
            column.ColumnName = colName;
            dt.Columns.Add(column);
        }

        public static void AddColumnsWithType(this DataTable dt, Type type, params string[] variables)
        {
            for (int i = 0; i < variables.Length; i++)
            {
                dt.Columns.Add(variables[i], type);
            }
        }

        public static List<string> FindOperands(string expression)
        {
            expression = expression.Replace(')', ' ');
            expression = expression.Replace('(', ' ');
            expression = expression.Trim();

            if (!char.IsLetterOrDigit(expression[expression.Length - 1]) || !char.IsLetterOrDigit(expression[0]))
            {
                throw new Exception("The Equation is incorrect");
            }

            List<string> operands = new List<string>();
            string operand = "";
            for (int i = 0; i < expression.Length; i++)
            {
                var character = expression[i];


                // if the character is operator then add the operand into list 
                if (isOperator(operand, character))
                {
                    // check if variable is starting with numeric value like 34sdf+2
                    operand = operand.Trim();
                    CheckOperand(operand);
                    operands.Add(operand);
                    operand = "";
                }
                else if (i == expression.Length - 1)
                {
                    operand += character;
                    operand = operand.Trim();
                    CheckOperand(operand);
                    operands.Add(operand);
                }
                else
                {
                    operand += character;
                }

            }

            return operands.Select(p => p.Trim()).ToList();
        }

        private static bool isOperator(string operand, char character)
        {
            return !char.IsLetterOrDigit(character) && operand != "" && character != 32 && character != '_';
        }

        private static void CheckOperand(string operand)
        {

            if (char.IsDigit(operand.ElementAt(0)) && operand.Any(Char.IsLetter))
            {
                throw new Exception("Variables cannot start with numeric");
            }
        }
    }
}
