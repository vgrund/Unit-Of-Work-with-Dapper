using DapperUnitOfWork.Entities;
using System;
using System.Data;
using System.Data.Entity;

namespace DapperUnitOfWork.Repositories
{
    public class LivrariaContext : DbContext
    {
        public LivrariaContext()
            :base("LivrariaContext")
        {

        }

        public IDbConnection Connection()
        {
            var connection = Database.Connection;

            try
            {
                connection.Open();
            }
            catch (Exception e)
            {
            }

            return connection;
        }

        public DbSet<Estante> Estantes { get; set; }
        public DbSet<Livro> Livros { get; set; }
    }
}
