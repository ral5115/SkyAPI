using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class PedidoMov
    {
        public string F_CIA { get; set; }
        public string f431_id_co { get; set; }
        public string f431_id_tipo_docto { get; set; }
        public string f431_consec_docto { get; set; }
        public string f431_nro_registro { get; set; }
        public string f431_id_item { get; set; }
        public string f431_referencia_item { get; set; }
        public string f431_id_bodega { get; set; }
        public string f431_id_co_movto { get; set; }
        public string f431_id_un_movto { get; set; }
        public string f431_fecha_entrega { get; set; }
        public string f431_num_dias_entrega { get; set; }
        public string f431_id_lista_precio { get; set; }
        public string f431_id_unidad_medida { get; set; }
        public string f431_cant_pedida_base { get; set; }
        public string f431_precio_unitario { get; set; }
        public string f431_notas { get; set; }
    }
}
