using CSharpCleanArch.Application.DataTransport.Output;
using CSharpCleanArch.Domain;
using CSharpCleanArch.Domain.Entities;
using CSharpCleanArch.Infrastructure.Database.EntityFramework.Models;

namespace CSharpCleanArch.Infrastructure.Database.EntityFramework.Mappers;
public static class UsuarioModelMapper
{
    public static Usuario toDomain(this UsuarioModel model)
    {
        var entity = new Usuario(
            model.Cpf,
            model.Nome,
            model.Email,
            model.Nascimento);

        if (model.Cep != null && model.Numero != null && model.Complemento != null)
            entity.SetEndereco(model.Cep, model.Numero, model.Complemento);

        return entity;
    }

    public static UsuarioModel toModel(this Usuario entity)
    {
        var model = new UsuarioModel
        {
            Cpf = entity.Cpf,
            Nome = entity.Nome,
            Email = entity.Email,
            Nascimento = entity.Nascimento,
            Cep = entity.Endereco?.CEP,
            Numero = entity.Endereco?.Numero,
            Complemento = entity.Endereco?.Complemento
        };

        return model;
    }

    public static UsuarioOutputDto toOutputDto(this UsuarioModel model)
    {
        Endereco? endereco = null;
        if (model.Cep != null && model.Numero != null && model.Complemento != null)
            endereco = new Endereco(model.Cep, model.Numero, model.Complemento);

        var dto = new UsuarioOutputDto(
            model.Id,
            model.Nome,
            model.Email,
            model.Nascimento,
            endereco);

        return dto;
    }
}