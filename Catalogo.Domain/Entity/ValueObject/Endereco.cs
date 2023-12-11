using Catalogo.Domain.Enum;
using Catalogo.Domain.ValueObject;
using Catalogo.Helpers;
using System;



    public  class Endereco
    {
        public const int LogradouroMaxLength = 150;
        public virtual string Logradouro { get;  set; }

        public const int ComplementoMaxLength = 150;
        public virtual string Complemento { get;  set; }

        public const int NumeroMaxLength = 50;
        public virtual string Numero { get;  set; }

        public const int BairroMaxLength = 150;
        public virtual string Bairro { get;  set; }

        public const int CidadeMaxLength = 150;
        public virtual string Cidade { get;  set; }

        public virtual Uf? Uf { get;  set; }

        public virtual Cep Cep { get;  set; }

        public virtual GeoLocalizacao Localizacao { get; set; }

        public Endereco()
        {
            Cep= new Cep("00000000");
            Bairro = "";
            Cidade = "";
            Complemento = "";
            Logradouro = "";
            Numero = "";
            Localizacao = new GeoLocalizacao("0", "0", "0");
            Uf=null;
        }

        public Endereco(string logradouro, string complemento, string numero, string bairro,
            string cidade, Uf? uf, Cep cep)
        {
            SetCep(cep);
            SetBairro(bairro);
            SetCidade(cidade);
            SetComplemento(complemento);
            SetLogradouro(logradouro);
            SetNumero(numero);
            Localizacao = new GeoLocalizacao("0", "0", "0");
            SetUf(uf);
        }

        public void SetCep(Cep cep)
        {
            if (cep.Vazio())
                throw new Exception("CEP é obrigatório!");
            Cep = cep;
        }

        public void SetComplemento(string complemento)
        {
            if (string.IsNullOrEmpty(complemento))
                complemento = "";
            Complemento = TextoHelper.ToTitleCase(complemento);
        }

        public void SetLogradouro(string logradouro)
        {
            Guard.ForNullOrEmptyDefaultMessage(logradouro, "Endereço");
            Logradouro = TextoHelper.ToTitleCase(logradouro);
        }

        public void SetNumero(string numero)
        {
            Guard.ForNullOrEmptyDefaultMessage(numero, "Número");
            Numero = numero;
        }

        public void SetBairro(string bairro)
        {
            Guard.ForNullOrEmptyDefaultMessage(bairro, "Bairro");
            Bairro = TextoHelper.ToTitleCase(bairro);
        }

        public void SetCidade(string cidade)
        {
            Guard.ForNullOrEmptyDefaultMessage(cidade, "Cidade");
            Cidade = TextoHelper.ToTitleCase(cidade);
        }

        public void SetUf(Uf? uf)
        {
            if(!uf.HasValue)
                throw new Exception("Estado é obrigatório");
            Uf = uf;
        }

        public override string ToString()
        {
            return Logradouro + ", " + Numero + " - " + Complemento + " <br /> " + Bairro + " - " + Cidade + "/" + Uf;
        }

       
    }
