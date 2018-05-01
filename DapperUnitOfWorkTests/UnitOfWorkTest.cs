using DapperUnitOfWork.Entities;
using DapperUnitOfWork.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DapperUnitOfWorkTest
{
    [TestClass]
    public class UnitOfWorkTest
    {
        IUnitOfWork _uow;
        LivrariaContext _context;
        LivrariaRepository _livrariaRepository;

        public UnitOfWorkTest()
        {
            _context = new LivrariaContext();
            _uow = new UnitOfWork(_context.Connection());
            _livrariaRepository = new LivrariaRepository(_uow);
        }

        private Estante ConstroiEstante()
        {
            return new Estante() { Corredor = "1c" };
        }

        private Livro ConstroiLivro(Guid? EstanteId)
        {
            return new Livro() { Autor = "Token", Titulo = "Epic", EstanteId = EstanteId.Value };
        }

        [TestMethod]
        public void DeveInserirComSucesso()
        {
            var estante = ConstroiEstante();
            var livro = ConstroiLivro(estante.EstanteId);

            _uow.Begin();

            try
            {
                _livrariaRepository.AddEstante(estante);
                _livrariaRepository.AddLivro(livro);

                _uow.Commit();
            }
            catch (Exception e)
            {
                _uow.Rollback();
            }

            var estanteInserida = _livrariaRepository.GetEstanteById(estante.EstanteId);
            var livroInserido = _livrariaRepository.GetLivroById(livro.LivroId);

            Assert.AreNotEqual(null, estanteInserida);
            Assert.AreNotEqual(null, livroInserido);
            Assert.AreEqual(estante.EstanteId, estanteInserida.EstanteId);
            Assert.AreEqual(livro.LivroId, livroInserido.LivroId);
        }

        [TestMethod]
        public void DeveFalharInsercaoEDarRollbackEmEstante()
        {
            var estante = ConstroiEstante();
            var livro = ConstroiLivro(estante.EstanteId);

            _uow.Begin();

            try
            {
                _livrariaRepository.AddEstante(estante);
                livro.EstanteId = default(Guid);
                _livrariaRepository.AddLivro(livro);

                _uow.Commit();
            }
            catch (Exception e)
            {
                _uow.Rollback();
            }

            var estanteInserida = _livrariaRepository.GetEstanteById(estante.EstanteId);
            var livroInserido = _livrariaRepository.GetLivroById(livro.LivroId);

            Assert.AreEqual(null, estanteInserida);
            Assert.AreEqual(null, livroInserido);
        }
    }
}
