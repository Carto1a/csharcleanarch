using CSharpCleanArch.Domain.Common;

namespace CSharpCleanArch.Application.Repository;
public interface IRepository<TOut, TEn, TKey>
where TEn : BaseEntity
{
    Task<TEn> CreateAsync(TEn entity);
    Task DeleteAsync(TEn entity);
    Task<TEn> UpdateAsync(TEn entity);
    Task<TEn?> GetByIdAsync(TKey id);
    Task<List<TOut>> GetAllAsync();
}