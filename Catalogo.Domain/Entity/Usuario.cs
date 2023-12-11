
using Catalogo.Domain.ValueObject;
using Catalogo.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace Catalogo.Domain.Entities.Modules.Core
{
    public class Usuario :Base
    {
        public const int LoginMinLength = 6;
        public const int LoginMaxLength = 30;
        public const int SenhaMinLength = 6;
        public const int SenhaMaxLength = 30;


        public Cpf Cpf { get;  set; }
        public Email Email { get;  set; }
        public string Login { get;  set; }
      
        public Telefone Telefone { get;  set; }
        public byte[] Senha {  get ;  set; }

        public Guid TokenAlteracaoDeSenha { get; private set; }

        //Construtor EntityFramework
        public Usuario()
        {

        }

        public Usuario(string nome ,string login, Cpf cpf, Email email, string senha, string senhaConfirmacao, Telefone telefone)
        {
            Nome = nome;
            SetLogin(login);
            SetCpf(cpf);
            SetEmail(email);
            SetSenha(senha, senhaConfirmacao);
            Telefone = telefone;
           // Endereco = endereco;
            DtInclusao = DateTime.Now;
        }

        public Usuario(string nome, string login, Cpf cpf, Email email, Telefone telefone)
        {
            Nome = nome;
            SetLogin(login);
            SetCpf(cpf);
            SetEmail(email);
            Telefone = telefone;
            DtInclusao = DateTime.Now;
        }

        public void SetLogin(string login)
        {
            Guard.ForNullOrEmptyDefaultMessage(login, "Login");
            Guard.StringLength("Login", login, LoginMinLength, LoginMaxLength);
            Login = login;
        }

        public void SetCpf(Cpf cpf)
        {
            if (cpf == null)
                throw new Exception("Cpf Obrigatório");
            Cpf = cpf;
        }

        
        public void SetCpf(string cpf)
        {
            if ( String.IsNullOrEmpty( cpf))
                throw new Exception("Cpf Obrigatório");
            Cpf =  new Domain.ValueObject.Cpf(cpf);
        }

        public void SetEmail(Email email)
        {
            if (email == null)
                throw new Exception("E-mail Obrigatório");
            Email = email;
        }

        private void SetSenha(string senha, string senhaConfirmacao)
        {
            Guard.ForNullOrEmptyDefaultMessage(senha, "Senha");
            Guard.ForNullOrEmptyDefaultMessage(senhaConfirmacao, "Confirmação de Senha");
            Guard.StringLength("Senha", senha, SenhaMinLength, SenhaMaxLength);
            Guard.AreEqual(senha, senhaConfirmacao, "As senhas não conferem!");

            Senha = CriptografiaHelper.CriptografarSenha(senha);
        }

        public void AlterarSenha(string senhaAtual, string novaSenha, string confirmacaoDeSenha)
        {

           if(ValidarSenha(senhaAtual) || Senha==null)
            SetSenha(novaSenha, confirmacaoDeSenha);
        }

        public bool ValidarSenha(string senha)
        {
            try
            {
                Guard.ForNullOrEmptyDefaultMessage(senha, "Senha");
                var senhaCriptografada = CriptografiaHelper.CriptografarSenha(senha);
                if (!Senha.SequenceEqual(senhaCriptografada))
                    return false;
                else
                    return true;
            }
            catch
            {
                return false;
            }

        }

        public Guid GerarNovoTokenAlterarSenha()
        {
            TokenAlteracaoDeSenha = Guid.NewGuid();
            return TokenAlteracaoDeSenha;
        }

        public void AlterarSenha(Guid token, string novaSenha, string confirmacaoDeSenha)
        {
            if (!TokenAlteracaoDeSenha.Equals(token))
                throw new Exception("token para alteração de senha inválido!");
            SetSenha(novaSenha, confirmacaoDeSenha);
            GerarNovoTokenAlterarSenha();
        }

 
    }
}
