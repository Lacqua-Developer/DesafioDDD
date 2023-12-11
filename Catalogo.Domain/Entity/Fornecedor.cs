
using Catalogo.Domain.ValueObject;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Catalogo.Domain.Entities.Modules.Core
{
    public class Fornecedor : Base
    {
       
        public Endereco Endereco { get; set; }
        public Email Email { get; set; }
        public Telefone Telefone { get; set; }
        public Telefone Celular { get; set; }




        [DefaultValue(1)]
        public int TipoServico_Id { get; set; }




    }
}
