
using System.Text.RegularExpressions;


namespace Catalogo.Domain.ValueObject
{
    public class Email
    {
        public const int EnderecoMaxLength = 254;
        public string Endereco { get;  set; }

        //Construtor do EntityFramework
        protected Email()
        {

        }

        public Email(string endereco)
        {

            if(IsValid(endereco) == false)
                throw new Exception("E-mail inválido");

            Endereco = endereco;
        }

        public static bool IsValid(string email)
        {
            bool ret = true;
            if(email.Length > 1)
            {
                var regexEmail = new Regex(@"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");

                return regexEmail.IsMatch(email);
            }
            return ret;
        }
    }
}
