namespace CSharpCleanArch.Application.DataTransport.Input;
public record UsuarioInputDto(
    string cpf,
    string nome,
    string email,
    DateTime nascimento,
    string cep,
    string numero,
    string complemento
);