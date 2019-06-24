using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Negocio
{

    // Ejemplos para trabajar con Entity Framework (esquema DB Firts) a traves de Linqs
    public class RepositorioPersonas
    {
        //Variable con la cual accedo a la base de datos tanto para leer como para escribir. 
        PersonasDBEntities db;

        public RepositorioPersonas()
        {
            db = new PersonasDBEntities();
            db.Configuration.LazyLoadingEnabled = false; // Carga Diferida: Carga la entidad principal y todas sus relacionadas. Ej: Personas (ent principal) y toda la info de Ocupacion (entidad relacionada)
            db.Configuration.ProxyCreationEnabled = false;
        }

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

        // El metodo Include obliga a cargar la entidad relacionada aun cuando Lazy Loading está desactivado.
        // http://www.tuprogramacion.com/programacion/lazy-load-en-entity-framework/
        public List<Personas> ListarInclude()
        {
            List<Personas> resultadoPersonas = db.Personas.Include(p=>p.Ocupaciones).ToList();

            return resultadoPersonas;
        }
    
        // Mediante SqlQuery obtiene el resultado del SP y lo mapea automaticamente con la entidad persona. Esto funciona siempre y cuando los datos del resultado del SP y el objeto tienen los mismos nombres y tipos.
        public List<Personas> ListarSP()
        {
            var resultado = db.Database.SqlQuery<Personas>("EXEC SP_ListarPersonas").ToList();
            var resultadoSP = db.SP_ListarPersonas().ToList();

            return resultado;
        }

        // Se invoca al metodo SP_ListarPersonas que ejecuta el SP e indicamos expliciamente contra que objeto lo vamos a mapear. 
        public List<Personas> ListarSPv2()
        {
            var resultadoSP = db.SP_ListarPersonas().Select<SP_ListarPersonas_Result, Personas>(p => new Personas()
            {
                IdPersona = p.IdPersona,
                Nombre = p.Nombre,
                Apellido = p.Apellido

            }).ToList();

            return resultadoSP;
        }


        public Personas ObtenerPersona(int id)
        {
            Personas objPersona = db.Personas.Where(p => p.IdPersona == id).FirstOrDefault();
  
            return objPersona;
        }

    
        public Personas ObtenerPersonaSP(int id)
        {
            var resultado = db.Database.SqlQuery<Personas>("EXEC SP_ObtenerPersona  @NroCliente", new SqlParameter("@NroCliente", id)).FirstOrDefault();

            return resultado;
        }

        public int ObtenerCantidadElementosTabla()
        {
            int numeroElementos = db.Personas.Count();

            return numeroElementos;
        }

       
        public List<Personas> ObtenerPersonasOcupacionInclude(string ocupacion)
        {
            return db.Personas.Where(p => p.Ocupaciones.Descripcion == ocupacion).Include(p => p.Ocupaciones).ToList();
        }

        public List<Personas> ObtenerPersonasOcupacion(string ocupacion)
        {
            return db.Personas.Where(p => p.Ocupaciones.Descripcion == ocupacion).ToList();
        }

        public List<Personas> ObtenerPersonasOcupacion(List<string>  ocupaciones)
        {
            return db.Personas.Where(p => ocupaciones.Contains(p.Ocupaciones.Descripcion)).ToList();
        }

    }
}
