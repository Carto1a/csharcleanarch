using System.Text.RegularExpressions;

using CSharpCleanArch.Domain.Common;
using CSharpCleanArch.Domain.Validation;

namespace CSharpCleanArch.Domain.Entities;
public class Usuario : BaseEntity
{
    public string Cpf { get; private set; }
    public string Nome { get; private set; }
    public string Email { get; private set; }
    public DateTime Nascimento { get; private set; }
    public Endereco? Endereco { get; private set; }
    public int Idade => (DateTime.Now - Nascimento).Days / 365;

    public Usuario(
        string cpf,
        string nome,
        string email,
        DateTime nascimento)
    {
        Cpf = cpf;
        Nome = nome;
        Email = email;
        Nascimento = nascimento;

        Validate();
    }

    public void SetEndereco(string cep, string numero, string complemento)
    {
        Endereco = new Endereco(cep, numero, complemento);
    }

    public Usuario Validate()
    {
        var validation = new DomainValidation("Usuario");

        validation.Cpf(Cpf, nameof(Cpf));
        validation.MinValue(Idade, 18, nameof(Idade));

        validation.Check();
        return this;
    }
}