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

            //List<Personas> lstPersonasOcupacion = repositorio.ObtenerPersonasOcupacion("Medico");
            //List<Personas> lstPersonas = repositorio.ListarSP();

            List<Personas> lstPersonas2 = repositorio.Listar();
     //       List<Personas> lstPersonas3 = repositorio.ListarInclude();

            Personas objPersona = repositorio.ObtenerPersonaSP(1);

        }
    }
}
