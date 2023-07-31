using FluentAssertions;
using TestePratico.Domain.Entities;
using TestePratico.Domain.Validations;

namespace TestePratico.Domain.Tests
{
    public class UsuarioTest
    {
        [Fact]
        public void CriarUsuario_ComParametrosValidos_ResultadoObjetoValido()
        {
            Action action = () => new Usuario("Usuário teste", "A12345678");
            action.Should().NotThrow<DomainException>();
        }

        [Fact]
        public void CriarUsuario_ValorNomeVazio_DomainExceptionCampoObrigatorio()
        {
            Action action = () => new Usuario("", "A12345678");
            action.Should().Throw<DomainException>().WithMessage("Campo nome é obrigatório");
        }

        [Fact]
        public void CriarUsuario_ValorNomeCurto_DomainExceptionNomeCurtoDemais()
        {
            Action action = () => new Usuario("A", "A12345678");
            action.Should().Throw<DomainException>().WithMessage("Nome digitado curto demais. Valor mínimo de 2 caracteres");
        }

        [Fact]
        public void CriarUsuario_ValorNomeExtenso_DomainExceptionNomeExcedeLimite()
        {
            Action action = () => new Usuario("Usuario teste 1 Usuario teste 1 Usuario teste 1 Usuario teste 1", "A12345678");
            action.Should().Throw<DomainException>().WithMessage("Campo nome excedeu o limite de 50 caracteres");
        }

        [Fact]
        public void CriarUsuario_CampoSenhaVazio_DomainExceptionSenhaObrigatoria()
        {
            Action action = () => new Usuario("Usuário teste", "");
            action.Should().Throw<DomainException>().WithMessage("Campo senha é obrigatório");
        }

        [Fact]
        public void CriarUsuario_CampoSenhaSemValoresObrigatorios_DomainExceptionSenhaFraca()
        {
            Action action = () => new Usuario("Usuário teste", "123");
            action.Should().Throw<DomainException>().WithMessage("Senha fraca. O campo senha deve ser preenchido com pelo menos um número, uma letra maiúscula e oito caracteres. Valor passado: 123");
        }

        [Fact]
        public void CriarUsuario_ValorSenhaMuitoGrande_DomainExceptionSenhaExcedeLimite()
        {
            Action action = () => new Usuario("Usuário teste", "A12345678A12345678A12345678A12345678");
            action.Should().Throw<DomainException>().WithMessage("Senha digitada excedeu o limite de 20 caracteres");
        }
    }
}
