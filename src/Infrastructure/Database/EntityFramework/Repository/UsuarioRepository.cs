using CSharpCleanArch.Application.DataTransport.Output;
using CSharpCleanArch.Application.Mappers;
using CSharpCleanArch.Application.Repository;
using CSharpCleanArch.Domain.Entities;
using CSharpCleanArch.Infrastructure.Database.EntityFramework.Mappers;

using Microsoft.EntityFrameworkCore;

namespace CSharpCleanArch.Infrastructure.Database.EntityFramework.Repository;
public class UsuarioRepository : IUsuarioRepository
{
    private readonly DataContext _context;
    public UsuarioRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<Usuario> CreateAsync(Usuario entity)
    {
        var result = await _context.Usuarios.AddAsync(entity.toModel());
        return result.Entity.toDomain();
    }

    public Task DeleteAsync(Usuario entity)
    {
        return Task.Run(() =>
            _context.Usuarios.Remove(entity.toModel())
        );
    }

    public void DeleteByCpf(Usuario entity)
    {
        var _ = _context.Usuarios.Remove(entity.toModel());
    }

    public async Task<List<UsuarioOutputDto>> GetAllAsync()
    {
        var result = await _context.Usuarios
            .AsNoTracking()
            .Select(e => e.toOutputDto())
            .ToListAsync();
        return result;
    }

    public async Task<Usuario?> GetByCpfAsync(string cpf)
    {
        var result = await _context.Usuarios
            .FirstOrDefaultAsync(e =>
                e.Cpf == cpf);

        return result?.toDomain();
    }

    public async Task<Usuario?> GetByIdAsync(Guid id)
    {
        var result = await _context.Usuarios
            .FirstOrDefaultAsync(e =>
                e.Id == id);

        return result?.toDomain();
    }

    public Task<Usuario> UpdateAsync(Usuario entity)
    {
        return Task.Run(() =>
        {
            var result = _context.Usuarios.Update(entity.toModel());
            return result.Entity.toDomain();
        });
    }

    public Usuario UpdateByCpf(Usuario entity)
    {
        var result = _context.Usuarios.Update(entity.toModel());
        return result.Entity.toDomain();
    }
}