using Catalogo.Domain.Entities;
using Catalogo.Domain.Entities.Modules.Produtos;
using System.Collections.Generic;

namespace Catalogo.Domain.Entity.Tipos
{
    public class TipoProduto : Base
    {
        public virtual ICollection<ProdutoItem> ProdutoItems { get; set; }
    }
}
