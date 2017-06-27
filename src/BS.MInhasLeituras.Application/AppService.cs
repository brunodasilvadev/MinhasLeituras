using BS.MinhasLeituras.Infra.Data.Interfaces;

namespace BS.MinhasLeituras.Application
{
    public class AppService
    {
        private readonly IUnitOfwork _uow;

        public AppService(IUnitOfwork uow)
        {
            _uow = uow;
        }

        public void BeginTransaction()
        {
            _uow.BeginTransaction();
        }

        public void Commit()
        {
            _uow.Commit();
        }
    }
}
