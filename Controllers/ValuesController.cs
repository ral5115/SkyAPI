using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DAO;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            DataSet structure =  new DataSet();
            StringBuilder plane = new StringBuilder("0000001");

            SQLTransaction ejecutar = new SQLTransaction();
            structure = ejecutar.GetStruct();

            for (int i = 1; i < structure.Tables[0].Rows.Count; i++)
            {
                //var a = structure.Tables[0].Rows[i]["Orden"].ToString();

                if (structure.Tables[0].Rows[i]["Fuente"].ToString() == "")
                {
                    plane.Append(structure.Tables[0].Rows[i]["ValorFijo"].ToString());
                }                

                if (structure.Tables[0].Rows[i]["Orden"].ToString() == "1")
                    plane.AppendLine();
                
            }


            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
