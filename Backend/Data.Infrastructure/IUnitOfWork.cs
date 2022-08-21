namespace Data.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
        void SaveChanges();
    }
}
