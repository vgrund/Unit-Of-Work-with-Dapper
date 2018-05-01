using System;

namespace DapperUnitOfWork.Entities
{
    public class Livro
    {
        public Livro()
        {
            LivroId = Guid.NewGuid();
        }

        public Guid LivroId { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public Guid EstanteId { get; set; }
        public virtual Estante Estante { get; set; }
    }
}
