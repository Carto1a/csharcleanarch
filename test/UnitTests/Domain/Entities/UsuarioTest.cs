using CSharpCleanArch.Domain.Entities;

namespace UnitTests.Domain.Entities;
public class UsuarioTest
{
    [Fact]
    public void ThrowsExceptionWhenUsuarioCpfIsInvalid()
    {
        Assert.Throws<ArgumentException>(() =>
            new Usuario(
                "12345678999",
                "Carlos",
                "carlos@email.com",
                DateTime.Parse("1990-09-08")
            ).Validate());
    }

    [Fact]
    public void ReturnEderecoWhenSetEdereco()
    {
        var usuario = new Usuario(
            "123.456.789-99",
            "Carlos",
            "carlos@email.com",
            DateTime.Parse("1990-09-08")).Validate();

        var cep = "12389";
        var numero = "19";
        var complemento = "Beco";

        usuario.SetEndereco(cep, numero, complemento);

        Assert.NotNull(usuario.Endereco);
        Assert.Equal(cep, usuario.Endereco.CEP);
        Assert.Equal(numero, usuario.Endereco.Numero);
        Assert.Equal(complemento, usuario.Endereco.Complemento);
    }

    [Fact]
    public void ReturnUsuarioWhenIdadeIsBiggerThen17()
    {
        var idade = 18;
        var nascimento = DateTime.Now.AddYears(-idade);

        var usuario = new Usuario(
            "123.456.789-99",
            "Carlos",
            "carlos@email.com",
            nascimento).Validate();

        Assert.Equal(idade, usuario.Idade);
    }

    [Fact]
    public void ThrowExceptionWhenUsuarioIdadeIsLessThan18()
    {
        var idade = 17;
        var nascimento = DateTime.Now.AddYears(-idade);

        Assert.Throws<ArgumentException>(() =>
            new Usuario(
                "123.456.789-99",
                "Carlos",
                "carlos@email.com",
                nascimento
            ).Validate());
    }
}