using CSharpCleanArch.Application.Repository;

namespace CSharpCleanArch.Application.UseCases;
public class DeleteUsuarioByCpfUseCase
{
    private readonly IUsuarioRepository _repo;
    private readonly IUnitOfWork _uow;
    public DeleteUsuarioByCpfUseCase(
        IUsuarioRepository repo,
        IUnitOfWork uow)
    {
        _repo = repo;
        _uow = uow;
    }

    public async Task Handler(string cpf)
    {
        var usuario = await _repo.GetByCpfAsync(cpf);
        if (usuario == null)
            throw new Exception("Usuário não encontrado");

        _repo.DeleteByCpf(usuario);
        await _uow.SaveAsync();
    }
}