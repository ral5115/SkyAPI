﻿using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
        ExecuteQuery query;
        PlaneBuilder planeBuild;
        StringBuilder plane = new StringBuilder();
        int consectLine = 1;
        public static IConfiguration Configuration { get; set; }

        // POST api/values
        [HttpPost]
        public string Post([FromBody] List<JObject> value)
        {
            string result ;

            try
            {
                //llama la estructura del conector

                DataSet structure = new DataSet();

                SQLTransaction ejecutar = new SQLTransaction();
                structure = ejecutar.GetStruct();
                planeBuild = new PlaneBuilder();


                if (value != null)
                {
                    plane.Append(planeBuild.BuildInitial(structure, value[0]));//construye linea inicial

                    for (int j = 0; j < value.Count; j++)//recorre la lista de registros a enviar
                    {

                        string ConectorType = (string)value[j]["Conector"];//extrae el nombre del conector
                        JObject json = value[j];//extrae json del conector a enviar

                        plane.Append(planeBuild.BuildMasters(structure, json, ref consectLine));//construye encabezados o maestros
                        string Pano = plane.ToString();
                        plane.Append(planeBuild.BuildDetails(structure, json, ref consectLine));//construye movimientos


                    }

                    plane.Append(planeBuild.BuildFinal(structure, value[0], ref consectLine));//construye linea final


                    string Plano = plane.ToString();
                    String PlanoSinEtiquetas = Plano.Replace("<Linea>", "").Replace("</Linea>", "");
                    string cia = PlanoSinEtiquetas.Substring(17, 1);

                    var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
                    Configuration = builder.Build();
                   
                    if (Configuration.GetSection("GeneratePlane").Value.Equals("True"))
                    {
                    var SavePlane = new StreamWriter($@"C:\Users\Public\Documents\Pedido{DateTime.Now.ToString("ddMMyyyy")}.txt");
                    SavePlane.WriteLine(PlanoSinEtiquetas);
                    SavePlane.Close();
                    }
                    
                    result = planeBuild.SendInformationWS(Plano, cia);
                    return result;
                }
                return "No se envio ningun Body..";

            }
            catch (Exception e)
            {

                return e.Message;
            }
            

        }

        [Route("Query")]
        [HttpPost]
        public IActionResult Post([FromBody] QueryWSSiesa value)
        {
            try
            {
                query = new ExecuteQuery();
                return Ok(query.SendQueryWS(value));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
            
        }

        [HttpGet]
        public string Get()
        {
            return "Servicio SKYApi Ejecutandose...";
        }



    }
}
