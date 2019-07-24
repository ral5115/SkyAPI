using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.BLL
{
    public class PlaneBuilder
    {
        StringBuilder plane;

        public string BuildInitial( DataSet structure, JObject json)
        {

            try
            {
                plane = new StringBuilder("<Linea>000000100000001");
                DataRow[] structureDetail = structure.Tables[1].Select("desc_seccion = 'Inicial'");
                
                 if (structureDetail[structureDetail.Length-1]["Fuente"].ToString() == "")
                {
                    plane.Append(structureDetail[structureDetail.Length - 1]["ValorFijo"].ToString());
                }
                else
                {
                    plane.Append(((string)json[structureDetail[structureDetail.Length - 1]["Fuente"].ToString()]).PadLeft(3, '0'));

                }
                
            }
            catch (Exception)
            {

                throw;
            }
            plane.Append("</Linea>");
            return plane.ToString();
        }

        public string BuildMasters( DataSet structure, JObject json, ref int consectLine)
        {
            plane = new StringBuilder();
            DataRow[] structureDetail = structure.Tables[1].Select("desc_seccion = '" + json["Conector"].ToString() + "'");

            for (int i = 0; i < structureDetail.Length; i++)
            {
                if (structureDetail[i]["Orden"].ToString() == "1")
                {
                    plane.AppendLine();
                    consectLine++;
                    plane.Append("<Linea>"+(consectLine).ToString().PadLeft(7, '0'));
                    
                }
                //valida que sea fijo o variable
                if (structureDetail[i]["Fuente"].ToString() == "")
                {
                    plane.Append(structureDetail[i]["ValorFijo"].ToString());
                }
                else
                {
                    int length = (int)(structureDetail[i]["Tamano"]);

                    if (structureDetail[i]["Tipo"].ToString() == "Alfanumerico")//valida que sea numerico o alfanumerico
                    {
                        plane.Append(((string)json[structureDetail[i]["Fuente"].ToString()]).PadRight(length, ' '));
                    }
                    else
                    {

                        plane.Append(((string)json[structureDetail[i]["Fuente"].ToString()]).PadLeft(length, '0'));
                    }

                }
            }
            //var a = plane.ToString();
            plane.Append("</Linea>");
            return plane.ToString();
        }



        public string BuildDetails( DataSet structure, JObject json, ref int consectLine)
        {
            
            try
            {
                plane = new StringBuilder();
                int sections = structure.Tables[3].Rows.Count;
                for (int id = 0; id < sections; id++)
                {
                    DataRow[] structureDetail = structure.Tables[2].Select("desc_seccion = '" + structure.Tables[3].Rows[id]["desc_seccion"].ToString() + "'");
                    int details = json[structureDetail[0]["desc_seccion"].ToString()].Count();
                    for (int t = 0; t < details; t++)
                    {

                        for (int i = 0; i < structureDetail.Length; i++)
                        {

                            if (structureDetail[i]["Orden"].ToString() == "1")
                            {
                                plane.AppendLine();
                                consectLine++;
                                plane.Append("<Linea>" + (consectLine).ToString().PadLeft(7, '0'));


                            }

                            if (structureDetail[i]["Fuente"].ToString() == "")
                            {
                                plane.Append(structureDetail[i]["ValorFijo"].ToString());
                            }
                            else
                            {
                                int length = (int)(structureDetail[i]["Tamano"]);

                                if (structureDetail[i]["Tipo"].ToString() == "Alfanumerico")
                                {
                                    plane.Append(((string)json[structureDetail[i]["desc_seccion"].ToString()][t][structureDetail[i]["Fuente"].ToString()]).PadRight(length, ' '));
                                }
                                else
                                {
                                    plane.Append(((string)json[structureDetail[i]["desc_seccion"].ToString()][t][structureDetail[i]["Fuente"].ToString()]).PadLeft(length, '0'));
                                }

                            }
                            //var resultado = plane.ToString();
                        }
                        plane.Append("</Linea>");
                    }

                }
            }
            catch (Exception)
            {

                throw;
            }

            return plane.ToString();
        }


        public string BuildFinal(DataSet structure, JObject json, ref int consectLine)
        {

            try
            {
                plane = new StringBuilder();
                DataRow[] structureDetail = structure.Tables[1].Select("desc_seccion = 'Final'");
                plane.AppendLine();
                consectLine++;
                plane.Append("<Linea>"+(consectLine).ToString().PadLeft(7, '0'));

                for (int i = 0; i < structureDetail.Length; i++)
                {
                    if (structureDetail[i]["Fuente"].ToString() == "")
                    {
                        plane.Append(structureDetail[i]["ValorFijo"].ToString());
                    }
                    else
                    {
                        plane.Append(((string)json[structureDetail[i]["Fuente"].ToString()]).PadLeft(3, '0'));

                    }
                }
                plane.Append("</Linea>");

            }
            catch (Exception)
            {

                throw;
            }

            return plane.ToString();
        }


        public void SendInformationWS(string xml)
        {
            string xmlSend;

            //wsSIESA.WSUNOEESoap wSUNOEESoap = new wsSIESA.WSUNOEESoap();

            wsSIESA.WSUNOEESoap ws = new wsSIESA.WSUNOEESoapClient(wsSIESA.WSUNOEESoapClient.EndpointConfiguration.WSUNOEESoap12);
            wsSIESA.ImportarXMLRequest request = new wsSIESA.ImportarXMLRequest();
            

            xmlSend = "<Importar>";
            xmlSend += "<NombreConexion>Prueba_2</NombreConexion>";
            xmlSend += "<IdCia>1</IdCia>";
            xmlSend += "<Usuario>unoee</Usuario>";
            xmlSend += "<Clave>unoee</Clave>";
            xmlSend += "<Datos>";
            xmlSend += xml;
            xmlSend += "</Datos>";
            xmlSend += "</Importar>";

            request.printTipoError = 0;
            request.pvstrDatos = xmlSend;
            var result = ws.


    }
        public void GenerateXMLStruct(string plane)
        {
            
        }
    }
}
