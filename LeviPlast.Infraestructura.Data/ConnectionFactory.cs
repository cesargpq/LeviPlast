using LeviPlast.Transversal.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.EntityFrameworkCore;
using LeviPlast.Dominio.Entity;
namespace LeviPlast.Infraestructura.Data
{
    public class ConnectionFactory : DbContext
    {

        public ConnectionFactory(DbContextOptions<ConnectionFactory> options)
               : base(options)
        {

        }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

    }
}
