namespace desafio_picpay.Repositories
{
    public interface IRepository<T>
    {
        void Add(T entity);
    }
}
