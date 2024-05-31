using CSharpCleanArch.Application.DataTransport.Output;
using CSharpCleanArch.Application.Mappers;
using CSharpCleanArch.Application.Repository;
using CSharpCleanArch.Domain.Entities;
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
        var result = await _context.Usuarios.AddAsync(entity);
        return result.Entity;
    }

    public Task DeleteAsync(Usuario entity)
    {
        return Task.Run(() =>
            _context.Usuarios.Remove(entity)
        );
    }

    public async Task<List<UsuarioOutputDto>> GetAllAsync()
    {
        var result = await _context.Usuarios
            .AsNoTracking()
            .Select(e => e.toOutputDto())
            .ToListAsync();
        return result;
    }

    public async Task<Usuario?> GetByIdAsync(Guid id)
    {
        var result = await _context.Usuarios
            .FirstOrDefaultAsync(e =>
                e.Id == id);

        return result;
    }

    public Task<Usuario> UpdateAsync(Usuario entity)
    {
        return Task.Run(() =>
        {
            var result = _context.Usuarios.Update(entity);
            return result.Entity;
        });
    }
}