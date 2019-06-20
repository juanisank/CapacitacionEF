using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{

    
    public class RepositorioPersonas
    {   
        //Variable con la cual accedo a la base de datos tanto para leer como para escribir.
        PersonasDBEntities db = new PersonasDBEntities();

        public void Agregar(Personas paramPersona)
        {
            db.Personas.Add(paramPersona);
            db.SaveChanges();
        }

        public void Actualizar(Personas paramPersona)
        {
            Personas objPersona = db.Personas.Where(p => p.IdPersona == paramPersona.IdPersona).FirstOrDefault();
            objPersona.Nombre = paramPersona.Nombre;
            objPersona.Apellido = paramPersona.Apellido;

            db.SaveChanges();
        }

        public void Eliminar(Personas paramPersona)
        {
            Personas objPersona = db.Personas.Remove(paramPersona);

            db.SaveChanges();
        }

        public List<Personas> Listar()
        {
            List<Personas> resultadoPersonas = db.Personas.ToList();

            return resultadoPersonas;
        }

        public Personas ObtenerPersona(int id)
        {
            Personas objPersona = db.Personas.Where(p => p.IdPersona == id).FirstOrDefault();
            db.Personas.Count();

            return objPersona;
        }

        public Personas ObtenerPersonaSP(int id)
        {
            var resultado = db.Database.SqlQuery<Personas>("EXEC SP_ObtenerPersona  @NroCliente", new SqlParameter("@NroCliente", id)).FirstOrDefault();

            return resultado;
        }

        public List<Personas> ListarPersonasSP()
        {
            var resultado = db.Database.SqlQuery<Personas>("EXEC SP_ListarPersonas").ToList();
            var resultadoSP = db.SP_ListarPersonas().ToList();

            return resultado;
        }

        public List<Personas> ListarPersonasSPv2()
        {
            var resultadoSP = db.SP_ListarPersonas().Select<SP_ListarPersonas_Result, Personas>(p => new Personas()
            {
                IdPersona = p.IdPersona,
                Nombre = p.Nombre,
                Apellido = p.Apellido

            }).ToList();

            return resultadoSP;
        }

        public int ObtenerCantidadElementosTabla()
        {
            int numeroElementos = db.Personas.Count();

            return numeroElementos;
        }
    }
}
