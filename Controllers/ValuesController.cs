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
            string ConectorType = (string)value["Conector"];


            //foreach (var token in value.Children())
            //{
            //    foreach (var item in token.Children())
            //    {
            //        foreach (JProperty property in item.Children().Where(t => t is JProperty).OfType<JProperty>())
            //        {
            //            var a = property.Value;
            //            var h = property.Name;
            //        }

            //    }


            //}

            try
            {
                DataSet structure = new DataSet();
                StringBuilder plane = new StringBuilder("0000001");

                SQLTransaction ejecutar = new SQLTransaction();
                structure = ejecutar.GetStruct();

                int consectLine = 2;

                for (int i = 1; i < structure.Tables[0].Rows.Count; i++)
                {
                    if (structure.Tables[0].Rows[i]["Orden"].ToString() == "1")
                    {
                        plane.AppendLine();
                        plane.Append((consectLine).ToString().PadLeft(7,'0'));
                        consectLine++;
                    }
                        

                    if (structure.Tables[0].Rows[i]["Fuente"].ToString() == "")
                    {
                        plane.Append(structure.Tables[0].Rows[i]["ValorFijo"].ToString());
                    }
                    else
                    {
                        int length = (int)(structure.Tables[0].Rows[i]["Tamano"]);
                        if (structure.Tables[0].Rows[i]["Tipo"].ToString() == "Alfanumerico")
                        {
                            plane.Append(((string)value[structure.Tables[0].Rows[i]["Fuente"].ToString()]).PadRight(length, ' '));
                        }
                        else
                        {
                            plane.Append(((string)value[structure.Tables[0].Rows[i]["Fuente"].ToString()]).PadLeft(length, '0'));
                        }

                    }

                    
                    var a = plane.ToString();
                }

                
            }
            catch (Exception e)

            {

                throw;
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
