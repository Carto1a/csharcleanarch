using CSharpCleanArch.Application.Repository;
using CSharpCleanArch.Domain.Entities;

namespace CSharpCleanArch.Application.UseCases;
public class CreateUsuarioUseCase
{
    private readonly IUsuarioRepository _repo;
    private readonly IUnitOfWork _uow;

    public CreateUsuarioUseCase(
        IUsuarioRepository repo,
        IUnitOfWork uow)
    {
        _repo = repo;
        _uow = uow;
    }

    public async Task<Usuario> Handler(Usuario usuario)
    {
        var entity = await _repo.CreateAsync(usuario);
        await _uow.SaveAsync();
        return entity;
    }
}