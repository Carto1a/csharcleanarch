using CSharpCleanArch.Domain;

namespace CSharpCleanArch.Application.DataTransport.Output;
public record UsuarioOutputDto(
    Guid id,
    string nome,
    string email,
    DateTime nascimento,
    Endereco? endereco
);