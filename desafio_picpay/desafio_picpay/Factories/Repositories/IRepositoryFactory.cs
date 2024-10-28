using desafio_picpay.Models.Entities;
using desafio_picpay.Repositories;

namespace desafio_picpay.Factories.Repositories
{
    public interface IRepositoryFactory
    {
        IRepository<T> GetRepository<T>() where T : class;
    }
}
