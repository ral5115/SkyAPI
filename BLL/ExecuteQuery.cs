

namespace WebAPI.BLL
{
    using System.Data;
    using WebAPI.Models;
   
    public class ExecuteQuery
    {
        public DataSet SendQueryWS(QueryWSSiesa query)
        {
            DataSet data = new DataSet();
            string xml = "";


            wsSIESA.WSUNOEESoap ws = new wsSIESA.WSUNOEESoapClient(wsSIESA.WSUNOEESoapClient.EndpointConfiguration.WSUNOEESoap);
            //var a = ws.EjecutarConsultaXMLAsync().Result;

            return data;
        }
    }
}
