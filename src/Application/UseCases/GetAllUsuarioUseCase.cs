using CSharpCleanArch.Application.DataTransport.Output;
using CSharpCleanArch.Application.Repository;

namespace CSharpCleanArch.Application.UseCases;
public class GetAllUsuariosUseCase
{
    private readonly IUsuarioRepository _repository;
    public GetAllUsuariosUseCase(IUsuarioRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<UsuarioOutputDto>> Handler()
    {
        return await _repository.GetAllAsync();
    }
}