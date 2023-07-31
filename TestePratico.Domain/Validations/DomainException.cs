namespace TestePratico.Domain.Validations
{
    public class DomainException : Exception
    {
        public DomainException(string erro) : base(erro) { }

        public static void Validar(bool possuiErros, string erro)
        {
            if (possuiErros) throw new DomainException(erro);
        }
    }
}
