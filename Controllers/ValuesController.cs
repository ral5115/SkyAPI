using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebAPI.BLL;
using WebAPI.DAO;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        PlaneBuilder planeBuild;
        StringBuilder plane = new StringBuilder();
        int consectLine = 2;

        // POST api/values
        [HttpPost]
        public void Post([FromBody] List<JObject> value)
        {
            
            //llama la estructura del conector
            DataSet structure = new DataSet();
            SQLTransaction ejecutar = new SQLTransaction();
            structure = ejecutar.GetStruct();
            
                
            if (value != null)
            {
                for (int j = 0; j < value.Count; j++)
                {

                    string ConectorType = (string)value[j]["Conector"];
                    JObject json = value[j];
                    planeBuild = new PlaneBuilder();
                    plane.Append( planeBuild.BuildMasters(j,structure, json, ref consectLine));
                    
                    try
                    {
                        

                        


                    }
                    catch (Exception e)

                    {

                        throw;
                    }


                }
            }


        }

       
        
    }
}
