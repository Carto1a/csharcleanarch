using CSharpCleanArch.Application.DataTransport.Input;
using CSharpCleanArch.Application.DataTransport.Output;
using CSharpCleanArch.Domain.Entities;

namespace CSharpCleanArch.Application.Mappers;
public static class UsuarioMapper
{
    public static Usuario toDomain(this UsuarioInputDto dto)
    {
        var entity = new Usuario(
            dto.cpf,
            dto.nome,
            dto.email,
            dto.nascimento);

        entity.SetEndereco(dto.cep, dto.numero, dto.complemento);

        return entity;
    }

    public static UsuarioOutputDto toOutputDto(this Usuario entity)
    {
        var dto = new UsuarioOutputDto(
            entity.Id,
            entity.Nome,
            entity.Email,
            entity.Nascimento,
            entity.Endereco);

        return dto;
    }
}