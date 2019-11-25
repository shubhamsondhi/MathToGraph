using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using MathToGraph.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MathToGraph.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquationSolverController : ControllerBase
    {

        // GET: api/EquationSolver
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/EquationSolver/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/EquationSolver
        [HttpPost("GetVariablesName")]
        public string[] GetVariablesName([FromBody]string eq)
        {
            // find the operands from the equation
            List<string> operands = EquationHelper.FindOperands(expression: eq);

            // Remove the numaric values
            var variables = operands.Where(p => p.Any(char.IsLetter)).ToArray();
            return variables;
        }

        // POST: api/EquationSolver
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///  {
        ///      "equation": "a+b",
        ///      "jsonData": "[{\"a\":\"10\",\"b\":\"39\"},
        ///      {\"a\":\"20\",\"b\":\"39\"},
        ///      {\"a\":\"30\",\"b\":\"39\"},
        ///      {\"a\":\"60\",\"b\":\"39\"}]";,
        ///      "resultColName": "Total"
        /// }
        /// <remarks>
        /// <param name="value">   
        /// </param>
        /// <returns></returns>
        [HttpPost]
        public double[] Post([FromBody]Data value)
        {
            //value.Equation = "a+b";

            //value.JsonData = "[{\"a\":\"10\",\"b\":\"39\"}," +
            //    "{\"a\":\"20\",\"b\":\"39\"}," +
            //    "{\"a\":\"30\",\"b\":\"39\"}," +
            //     "{\"a\":\"60\",\"b\":\"39\"}]";
            var table = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(value.JsonData);
            var variables = GetVariablesName(value.Equation);

            DataTable dt = new DataTable();

            var tableColHeader = table[0].Select(tk => tk.Key).ToArray();

            if (tableColHeader.Any(bs => !variables.Contains(bs)))
            {
                throw new Exception("header do not match with variables");
            };

            // create columns with type
            dt.AddColumnsWithType(typeof(double), tableColHeader);

            // add values 
            // right now adding 10 random values
            for (int i = 0; i < table.Count; i++)
            {
                DataRow dr = dt.NewRow(); //Creating a New Row  
                var row = table[i];

                for (int k = 0; k < variables.Length; k++)
                {
                    dr[variables[k]] = row[variables[k]];
                }
                dt.Rows.Add(dr); // Add the Row to the DataTable  
            }

            dt.CreateSolutionColumn(value.Equation, typeof(double), value.resultColName);

            var result = Enumerable.Range(0, dt.Rows.Count).Select(p => (double)dt.Rows[p][value.resultColName]).ToArray();
            return result;
        }

        // PUT: api/EquationSolver/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
