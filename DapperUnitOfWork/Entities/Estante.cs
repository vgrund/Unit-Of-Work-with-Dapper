using System;
using System.Collections.Generic;

namespace DapperUnitOfWork.Entities
{
    public class Estante
    {
        public Estante()
        {
            EstanteId = Guid.NewGuid();
        }

        public Guid EstanteId { get; set; }
        public string Corredor { get; set; }
        public virtual IEnumerable<Livro> Livros { get; set; }
    }
}
