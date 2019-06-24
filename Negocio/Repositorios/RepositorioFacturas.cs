using Negocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    // Ejemplos de Linq trabajando en memoria con colecciones (List)
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

        //SM: Linq Sintaxis de Metodos, utiliza metodos de extension con expresiones Lamda
        public Factura ObtenerFacturaSM(int nroFactura)
        {
            return lstFacturas.Where(p => p.NroFactura == nroFactura).FirstOrDefault();
        }

        //SC: Linq Sintaxis de Consulta. Se realiza sobre la coleccion un tipo de consulta estilo SQL. 
        public Factura ObtenerFacturaSC(int nroFactura)
        {
            return (from p in lstFacturas where p.NroFactura == nroFactura select p).FirstOrDefault();
        }

        //Devuelvo objeto anonimo, un que existe solo en tiempo de ejecuccion. Estos tipos de objetos pueden ser capturados y tenerlos tipados a partir de inferencia de tipos "var"
        public Object ObtenerFacturaSCv2(int nroFactura)
        {

            var objAnonimo = (from p in lstFacturas
                              where p.NroFactura == nroFactura
                              select new
                              {
                                  NumeroFactura = p.NroFactura,
                                  Total = p.MontoTotal

                              }).FirstOrDefault();


            return objAnonimo;
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

        public List<Factura> ObtenerFacturasPorRangoMontos(double montoMin, double montoMax)
        {
            return lstFacturas.Where(p=> p.MontoTotal > montoMin && p.MontoTotal<montoMax).ToList();
        }

        public int ObtenerCantidadFacturasPorCliente(string Cliente)
        {
            return lstFacturas.Where(p => p.Cliente == Cliente).Count();
        }

    }

}
