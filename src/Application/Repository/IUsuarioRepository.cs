using CSharpCleanArch.Application.DataTransport.Output;
using CSharpCleanArch.Domain.Entities;

namespace CSharpCleanArch.Application.Repository;
public interface IUsuarioRepository
: IRepository<UsuarioOutputDto, Usuario, Guid>
{ }