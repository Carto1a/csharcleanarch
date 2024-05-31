using CSharpCleanArch.Application;

namespace CSharpCleanArch.Infrastructure.Database.EntityFramework.Repository;
public class UnitOfWork : IUnitOfWork
{
    private readonly DataContext _context;
    private bool disposed = false;
    public UnitOfWork(DataContext context)
    {
        _context = context;
    }

    public Task SaveAsync()
    {
        return _context.SaveChangesAsync();
    }

    public Task CommitAsync()
    {
        return _context.SaveChangesAsync();
    }

    public void Rollback()
    {
        throw new NotImplementedException();
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
            if (disposing)
                _context.Dispose();

        disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

}