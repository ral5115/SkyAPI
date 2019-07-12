using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebAPI.DAO;
using WebAPI.Models;

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
            //DataSet structure =  new DataSet();
            //StringBuilder plane = new StringBuilder("0000001");

            //SQLTransaction ejecutar = new SQLTransaction();
            //structure = ejecutar.GetStruct();

            //for (int i = 1; i < structure.Tables[0].Rows.Count; i++)
            //{
            //    //var a = structure.Tables[0].Rows[i]["Orden"].ToString();

            //    if (structure.Tables[0].Rows[i]["Fuente"].ToString() == "")
            //    {
            //        plane.Append(structure.Tables[0].Rows[i]["ValorFijo"].ToString());
            //    }                

            //    if (structure.Tables[0].Rows[i]["Orden"].ToString() == "1")
            //        plane.AppendLine();
                
            //}

            //var a = plane.ToString();
            return new string[] { "", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] JObject value)
        {
            DataSet ds = new DataSet();


            foreach (JProperty property in value.Children().Where(t => t is JProperty).OfType<JProperty>())
            {
                var a = property.Value;
                
            }

            string fieldName = "";

            foreach (var token in value.Children())
            {
                foreach (var item in token.Children())
                {
                    var x = item;
                    foreach (JProperty property in item.Children().Where(t => t is JProperty).OfType<JProperty>())
                    {

                        var a = property.Value;
                        var t = property.Name;
                        //var r = item2;
                        //var t = r.Path;
                        //var i = t.Remove(0, 8);
                        //var h = r[i.ToString()].ToString();
                    }
                    //var m = item.Value;
                }

                string replaceString = "%{" + token.Path + "}";
                fieldName = fieldName.Replace(replaceString, value[token.Path].ToString());
                var n = value[token.Children()];
            }
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
