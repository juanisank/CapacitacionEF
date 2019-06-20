using Negocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Factura
    {
        public int NroFactura { get; set; }
        public string Cliente { get; set; }
        public double MontoTotal { get; set; }
        public List<ItemFactura> Items;


    }
}
