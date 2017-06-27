namespace BS.MinhasLeituras.Infra.Data.Interfaces
{
    public interface IUnitOfwork
    {
        void BeginTransaction();
        void Commit();
    }
}
