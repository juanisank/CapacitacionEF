using Negocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{

    public class RepositorioFacturas
    {
        List<Factura> lstFacturas = new List<Factura>();

        public RepositorioFacturas()
        {
            lstFacturas.Add(new Factura()
            {
                NroFactura = 1,
                Cliente = "Juan Perez",
                Items = new List<ItemFactura>()
                {
                new ItemFactura() { IdItem = 1, Producto = "Leche", Cantidad = 2, Precio = 10 },
                new ItemFactura() { IdItem = 2, Producto = "Manteca", Cantidad = 2, Precio = 5 }
                }
            });

            lstFacturas.Add(new Factura()
            {
                NroFactura = 1,
                Cliente = "Juan Perez",
                Items = new List<ItemFactura>()
                {
                new ItemFactura() { IdItem = 3, Producto = "Leche", Cantidad = 2, Precio = 10 },
                new ItemFactura() { IdItem = 4, Producto = "Vino", Cantidad = 2, Precio = 5 }
                }
            });

            lstFacturas.Add(new Factura()
            {
                NroFactura = 1,
                Cliente = "Luis Sosa",
                Items = new List<ItemFactura>()
                {
                new ItemFactura() { IdItem = 5, Producto = "Carne", Cantidad = 2, Precio = 10 },
                new ItemFactura() { IdItem = 6, Producto = "Pan", Cantidad = 25, Precio = 5 }
                }
            });

            lstFacturas.Add(new Factura()
            {
                NroFactura = 1,
                Cliente = "Marta Gonzales",
                Items = new List<ItemFactura>()
                {
                new ItemFactura() { IdItem = 7, Producto = "Leche", Cantidad = 1, Precio = 10 },
                new ItemFactura() { IdItem = 8, Producto = "Detergente", Cantidad = 4, Precio = 5 }
                }
            });
        }

        public Factura ObtenerFactura(int nroFactura)
        {
            return lstFacturas.Where(p => p.NroFactura == nroFactura).FirstOrDefault();
        }

        public Factura ObtenerFacturaMasCara()
        {
            double precioMaximo = lstFacturas.Max(p => p.MontoTotal);

            return lstFacturas.Where(p => p.MontoTotal == precioMaximo).FirstOrDefault();
        }

        public List<Factura> ObtenerFacturasOrdenadasPorCliente()
        {
            return lstFacturas.OrderBy(p => p.Cliente).ToList();
        }

        public int ObtenerCantidadFacturasPorCliente(string Cliente)
        {
            return lstFacturas.Where(p => p.Cliente == Cliente).Count();
        }

    }

}
