using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio;

namespace Consola.Test
{
    class Program
    {
        static void Main(string[] args)
        {

            RepositorioPersonas repositorio = new RepositorioPersonas();

            Personas objPersona = new Personas();
            objPersona.IdPersona = 2;
            objPersona.Nombre = "Raul";
            objPersona.Apellido = "Sosa";

           var elemento = repositorio.ObtenerPersonaSP(1);

        }
    }
}
