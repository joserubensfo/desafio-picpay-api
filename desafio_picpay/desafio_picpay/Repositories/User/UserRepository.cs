using desafio_picpay.Models.Entities;

namespace desafio_picpay.Repositories.User
{
    public class UserRepository : IUserRepository
    {
        public void Add(Models.Entities.User user)
        {
            int lastID = StaticDataBase.tbUser.Last()?.ID ?? 0;
            user.ID = lastID + 1;
            StaticDataBase.tbUser.Add(user as Models.Entities.User);
        }
    }
}
