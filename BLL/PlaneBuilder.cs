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
        public string BuildMasters(int im, DataSet structure, JObject json, ref int consectLine)
        {
             plane=new StringBuilder("0000001");

            for (int i = 1; i < structure.Tables[1].Rows.Count; i++)
            {
                if (structure.Tables[1].Rows[i]["Orden"].ToString() == "1")
                {
                    plane.AppendLine();
                    plane.Append((consectLine).ToString().PadLeft(7, '0'));
                    consectLine++;
                }
                //valida que sea fijo o variable
                if (structure.Tables[1].Rows[i]["Fuente"].ToString() == "")
                {
                    plane.Append(structure.Tables[1].Rows[i]["ValorFijo"].ToString());
                }
                else
                {
                    int length = (int)(structure.Tables[1].Rows[i]["Tamano"]);

                    if (structure.Tables[1].Rows[i]["Tipo"].ToString() == "Alfanumerico")//valida que sea numerico o alfanumerico
                    {
                        plane.Append(((string)json[structure.Tables[1].Rows[i]["Fuente"].ToString()]).PadRight(length, ' '));
                    }
                    else
                    {

                        plane.Append(((string)json[structure.Tables[1].Rows[i]["Fuente"].ToString()]).PadLeft(length, '0'));
                    }

                }
            }
            consectLine++;
            return plane.ToString();
        }
        public string BuildDetails(int details, DataSet structure, JObject json, ref int consectLine)
        {
            for (int id = 0; id < details; id++)
            {
                for (int i = 1; i < structure.Tables[2].Rows.Count; i++)
                {
                    string section = structure.Tables[2].Rows[i]["desc_seccion"].ToString();
                    if (structure.Tables[2].Rows[i]["Orden"].ToString() == "1")
                    {
                        plane.AppendLine();
                        plane.Append((consectLine).ToString().PadLeft(7, '0'));
                        consectLine++;
                    }

                    if (structure.Tables[2].Rows[i]["Fuente"].ToString() == "")
                    {
                        plane.Append(structure.Tables[2].Rows[i]["ValorFijo"].ToString());
                    }
                    else
                    {
                        int length = (int)(structure.Tables[2].Rows[i]["Tamano"]);
                        if (structure.Tables[2].Rows[i]["Tipo"].ToString() == "Alfanumerico")
                        {
                            plane.Append(((string)json[section][id][structure.Tables[2].Rows[i]["Fuente"].ToString()]).PadRight(length, ' '));
                        }
                        else
                        {
                            plane.Append(((string)json[section][id][structure.Tables[2].Rows[i]["Fuente"].ToString()]).PadLeft(length, '0'));
                        }

                    }
                    var a = plane.ToString();
                }
                consectLine++;
            }

            return plane.ToString();
        }

    }
}
