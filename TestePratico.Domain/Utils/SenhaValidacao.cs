using System.Text.RegularExpressions;

namespace TestePratico.Domain.Utils
{
    public static class SenhaValidacao
    {
        public static bool ValidarSenha(string senha)
        {
            //Senha dever contêr pelo menos oito caracteres, um número e uma letra maiúscula
            Regex regex = new Regex(@"^(.{0,7}|[^0-9]*|[^A-Z])$");
            Match match = regex.Match(senha);
            return match.Success;
        }
    }
}
