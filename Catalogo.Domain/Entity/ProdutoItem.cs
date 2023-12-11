

using Catalogo.Domain.Entity.Tipos;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Catalogo.Domain.Entities.Modules.Produtos
{
    public class ProdutoItem : Base
    {

        public decimal Preco { get; set; }
        public string Modelo { get; set; }
        public string Descricao { get; set; }
        public string Codigo { get; set; }

        public int Image_Id { get; set; }
        public int Marca_Id { get; set; }
        public int Categotia_Id { get; set; }
        public int TipoProduto_Id { get; set; }

        [ForeignKey("Image_Id")]
        public virtual Image Image { get; set; }
        [ForeignKey("Marca_Id")]
        public virtual TipoMarca Marca { get; set; }
        [ForeignKey("Categotia_Id")]
        public virtual Categoria Categotia { get; set; }
        [ForeignKey("TipoProduto_Id")]
        public virtual TipoProduto TipoProduto { get; set; }



    }
}
