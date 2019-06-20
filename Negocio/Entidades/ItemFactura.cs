using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Entidades
{
    public class ItemFactura
    {
        public int IdItem { get; set; }
        public string Producto { get; set; }
        public double Cantidad { get; set; }
        public double Precio { get; set; }
    }
}
