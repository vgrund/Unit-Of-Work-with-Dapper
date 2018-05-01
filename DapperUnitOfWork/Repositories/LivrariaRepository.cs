using DapperUnitOfWork.Entities;
using Dapper;
using System.Text;
using System;
using System.Linq;

namespace DapperUnitOfWork.Repositories
{
    public class LivrariaRepository
    {
        private readonly IUnitOfWork _uow;
        public LivrariaRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public void AddEstante(Estante estante)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("insert into Estantes (EstanteId, Corredor) values (@EstanteId, @Corredor)");

            _uow.Connection.Execute(sql.ToString(), new { estante.EstanteId, estante.Corredor }, _uow.Transaction);
        }

        public void AddLivro(Livro livro)
        {
            StringBuilder sql = new StringBuilder();
            //sql.AppendLine($"insert into Livro (LivroId, Titulo, Autor, EstanteId) values ('{livro.LivroId}','{livro.Titulo}','{livro.Autor}', '{livro.EstanteId}'");
            sql.AppendLine("insert into Livroes (LivroId, Titulo, Autor, EstanteId) values (@LivroId,@Titulo,@Autor,@EstanteId)");

            _uow.Connection.Execute(sql.ToString(), new {  livro.LivroId,  livro.Titulo,  livro.Autor,  livro.EstanteId }, _uow.Transaction);
        }

        public Estante GetEstanteById(Guid EstanteId)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine(" select * from Estantes where EstanteId = @EstanteId");

            return _uow.Connection.Query<Estante>(sql.ToString(), new { EstanteId }, _uow.Transaction).FirstOrDefault();
        }

        public Livro GetLivroById(Guid LivroId)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine(" select * from Livroes where LivroId = @LivroId");

            return _uow.Connection.Query<Livro>(sql.ToString(), new { LivroId }, _uow.Transaction).FirstOrDefault();
        }
    }
}
