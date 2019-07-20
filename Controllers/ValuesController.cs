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
        int consectLine = 1;

        // POST api/values
        [HttpPost]
        public void Post([FromBody] List<JObject> value)
        {
            
            //llama la estructura del conector
            DataSet structure = new DataSet();
            SQLTransaction ejecutar = new SQLTransaction();
            structure = ejecutar.GetStruct();
            planeBuild = new PlaneBuilder();
            

            if (value != null)
            {
                plane.Append(planeBuild.BuildInitial(structure, value[0]));//construye linea inicial
                for (int j = 0; j < value.Count; j++)
                {
                  try
                    {
                    string ConectorType = (string)value[j]["Conector"];
                    JObject json = value[j];
                    
                    plane.Append( planeBuild.BuildMasters(structure, json, ref consectLine));//construye encabezados o maestros
                    plane.Append(planeBuild.BuildDetails(structure, json, ref consectLine));//construye movimientos
                   }
                    catch (Exception e)
                    {
                        throw;
                    }


                }
                plane.Append(planeBuild.BuildFinal(structure, value[0], ref consectLine));//construye linea final
                string Plano = plane.ToString();


            }


        }

        
        

    }
}
