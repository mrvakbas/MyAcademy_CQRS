namespace MyAcademyCQRS.Context
{
    public interface IUnitOfWork
    {
        AppDbContext Context { get; }
        Task<int> SaveChangesAsync();
        Task BeginTransactionAsync();
        Task CommitAsync();
        Task RollbackAsync();
    }
}
