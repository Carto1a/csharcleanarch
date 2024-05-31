namespace CSharpCleanArch.Application;
public interface IUnitOfWork : IDisposable
{
    Task SaveAsync();
    Task CommitAsync();
    void Rollback();
}