using CSharpCleanArch.Domain.Common;

namespace CSharpCleanArch.Infrastructure.Database.EntityFramework.Models;
public class UsuarioModel : BaseEntity
{
    public required string Cpf { get; set; }
    public required string Nome { get; set; }
    public required string Email { get; set; }
    public DateTime Nascimento { get; set; }
    public string? Complemento { get; set; }
    public string? Cep { get; set; }
    public string? Numero { get; set; }
}