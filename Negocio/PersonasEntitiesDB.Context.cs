﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Negocio
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class PersonasDBEntities : DbContext
    {
        public PersonasDBEntities()
            : base("name=PersonasDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Personas> Personas { get; set; }
        public virtual DbSet<Ocupaciones> Ocupaciones { get; set; }
    
        public virtual ObjectResult<SP_ListarPersonas_Result> SP_ListarPersonas()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_ListarPersonas_Result>("SP_ListarPersonas");
        }
    
        public virtual ObjectResult<SP_ObtenerPersona_Result> SP_ObtenerPersona(Nullable<int> idPersona)
        {
            var idPersonaParameter = idPersona.HasValue ?
                new ObjectParameter("IdPersona", idPersona) :
                new ObjectParameter("IdPersona", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_ObtenerPersona_Result>("SP_ObtenerPersona", idPersonaParameter);
        }
    }
}
