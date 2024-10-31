using desafio_picpay.Repositories;
using desafio_picpay.Repositories.Shopkeeper;
using desafio_picpay.Repositories.User;
using desafio_picpay.Shared.Models.Entities;

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
            try
            {
                object? repository = null;

                if (typeof(T) == typeof(User))
                {
                    repository = _serviceProvider.GetService(typeof(IUserRepository))!;
                }
                else if (typeof(T) == typeof(Shopkeeper))
                {
                    repository = _serviceProvider.GetService(typeof(IShopkeeperRepository))!;
                }

                if(repository == null)
                {
                    throw new ArgumentException("Unsupported repository type.");
                }

                return (IRepository<T>)repository;
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Erro: {ex.Message}");
            }
        }
    }
}
