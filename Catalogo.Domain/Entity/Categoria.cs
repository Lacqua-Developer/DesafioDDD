using System.Collections.Generic;

namespace Catalogo.Domain.Entities.Modules.Produtos
{
    public class Categoria : Base
    {
        public virtual ICollection<ProdutoItem> ProdutoItems { get; set; }
    }
}
