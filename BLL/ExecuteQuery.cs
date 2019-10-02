

namespace WebAPI.BLL
{
    using System.Data;
    using System.Xml.Linq;
    using WebAPI.Models;
   
    public class ExecuteQuery
    {
        public XElement SendQueryWS(QueryWSSiesa query)
        {
            try
            {
                DataSet data = new DataSet();
                string xml = "<Consulta>";
                xml += $"<NombreConexion>{query.ConectionName}</NombreConexion>";
                xml += $"<IdCia>{query.Cia}</IdCia>";
                xml += $"<IdProveedor>{query.Provider}</IdProveedor>";
                xml += $"<IdConsulta>{query.NameQuery}</IdConsulta>";
                xml += $"<Usuario>{query.User}</Usuario>";
                xml += $"<Clave>{query.Pass}</Clave>";
                xml += "<Parametros>";
                for (int i = 0; i < query.Filters.Count; i++)
                {
                    string[] filters = query.Filters[i].Split(":");
                    xml += $"<{filters[0]}>{filters[1]}</{filters[0]}>";
                }
                xml += "</Parametros>";
                xml += "</Consulta>";

                wsSIESA.WSUNOEESoap ws = new wsSIESA.WSUNOEESoapClient(wsSIESA.WSUNOEESoapClient.EndpointConfiguration.WSUNOEESoap);
                var result = ws.EjecutarConsultaXMLAsync(xml).Result;
                return result.Nodes[1];
            }
            catch (System.Exception e)
            {

                throw e;
            }
           

        }
    }
}
