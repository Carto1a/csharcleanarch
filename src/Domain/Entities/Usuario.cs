using System.Text.RegularExpressions;

using CSharpCleanArch.Domain.Common;

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
        if (Cpf == null ||
            !Regex.IsMatch(Cpf, @"^\d{3}\.\d{3}\.\d{3}-\d{2}$"))
            throw new ArgumentException("CPF inválido");

        if (Idade < 18)
            throw new ArgumentException("Deve ser maior de 18 anos");

        return this;
    }
}