using CSharpCleanArch.Application.Repository;
using CSharpCleanArch.Domain.Entities;

namespace CSharpCleanArch.Application.UseCases;
public class UpdateUsuarioByCpfUseCase
{
    private readonly IUsuarioRepository _repo;
    private readonly IUnitOfWork _uow;
    public UpdateUsuarioByCpfUseCase(
        IUsuarioRepository repo,
        IUnitOfWork uow)
    {
        _repo = repo;
        _uow = uow;
    }

    public async Task<Usuario> Handler(string cpf, Usuario entity)
    {
        var usuario = await _repo.GetByCpfAsync(entity.Cpf);
        if (usuario == null)
            throw new Exception("Usuário não encontrado");

        var result = await _repo.UpdateAsync(usuario);
        await _uow.SaveAsync();

        return result;
    }
}