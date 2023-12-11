using System;
using System.ComponentModel.DataAnnotations;


namespace Catalogo.Domain.Entities
{
    public  abstract class Base
    {
        private string nome;

        [Key]
        public int Id { get; set; }
        public string Nome { get { return nome;  } set { nome = (value != null?  value.ToUpper() : null) ; } }
        public DateTime? DtInclusao { get; set; }
        public DateTime? DtAlteracao { get; set; }

   }
}
