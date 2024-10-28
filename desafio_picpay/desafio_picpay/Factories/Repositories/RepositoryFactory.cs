using desafio_picpay.Models.Entities;
using desafio_picpay.Repositories;
using desafio_picpay.Repositories.Shopkeeper;
using desafio_picpay.Repositories.User;

namespace desafio_picpay.Factories.Repositories
{
    public class RepositoryFactory : IRepositoryFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public RepositoryFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            var repository = _serviceProvider.GetService(typeof(IShopkeeperRepository));

            if (repository == null)
            {
                throw new ArgumentException("Tipo de repositório não suportado.");
            }

            return (IRepository<T>)repository;

        }
    }
}
