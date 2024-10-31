namespace desafio_picpay.Repositories.User
{
    public class UserRepository : IUserRepository
    {
        public void Add(Shared.Models.Entities.User user)
        {
            int lastID = Database.tbUser.LastOrDefault()?.ID ?? 0;
            user.ID = lastID + 1;
            Database.tbUser.Add(user);
        }
    }
}
