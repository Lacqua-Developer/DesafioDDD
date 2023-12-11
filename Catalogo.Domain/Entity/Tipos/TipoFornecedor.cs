using Catalogo.Domain.Entities;
using Catalogo.Domain.Entities.Modules.Core;
using System.Collections.Generic;

namespace Catalogo.Domain.Entity.Tipos
{
    public class TipoFornecedor : Base
    {
        public virtual ICollection<Fornecedor> Fornecedores { get; set; }
    }
}
