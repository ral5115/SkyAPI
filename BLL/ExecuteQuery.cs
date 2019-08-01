

namespace WebAPI.BLL
{
    using System.Data;
    using WebAPI.Models;
   
    public class ExecuteQuery
    {
        public DataSet SendQueryWS(QueryWSSiesa query)
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
                xml += $"<IdCia>{}</IdCia>";
            }
            xml += "</Parametros>";
            xml += "</Consulta>";

           wsSIESA.WSUNOEESoap ws = new wsSIESA.WSUNOEESoapClient(wsSIESA.WSUNOEESoapClient.EndpointConfiguration.WSUNOEESoap);
            //var a = ws.EjecutarConsultaXMLAsync().Result;

            return data;
        }
    }
}
