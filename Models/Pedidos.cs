using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Pedidos
    {
        public string F_CIA { get; set; }
        public string f430_id_co { get; set; }
        public string f430_id_tipo_docto { get; set; }
        public string f430_consec_docto { get; set; }
        public string f430_id_fecha { get; set; }
        public string f430_id_tercero_fact { get; set; }
        public string f430_id_sucursal_fact { get; set; }
        public string f430_id_tercero_rem { get; set; }
        public string f430_id_sucursal_rem { get; set; }
        public string f430_id_tipo_cli_fact { get; set; }
        public string f430_id_co_fact { get; set; }
        public string f430_fecha_entrega { get; set; }
        public string f430_num_dias_entrega { get; set; }
        public string f430_num_docto_referencia { get; set; }
        public string f430_referencia { get; set; }
        public string f430_id_cond_pago { get; set; }
        public string f430_notas { get; set; }
        public string f430_id_tercero_vendedor { get; set; }
        public List<PedidoMov> PedidoMov { get; set; }
        public List<PedidoImp> PedidoImp { get; set; }
        public List<PedidoDesc> PedidoDesc { get; set; }
    }
}
