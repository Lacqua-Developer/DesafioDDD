

using Catalogo.Domain.Entities.Modules.Produtos;
using System.Collections.Generic;

namespace Catalogo.Domain.Entities
{
    public  class Image : Base
    {
        public string url { get; set; }
        public string Descicao { get; set; }

        public virtual ICollection<ProdutoItem> ProdutoItems { get; set; }
    }
}
