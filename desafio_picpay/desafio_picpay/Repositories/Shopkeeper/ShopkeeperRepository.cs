
namespace desafio_picpay.Repositories.Shopkeeper
{
    public class ShopkeeperRepository : IShopkeeperRepository
    {
        public void Add(Shared.Models.Entities.Shopkeeper shopkeeper)
        {
            int lastID = Database.tbShopkeeper.LastOrDefault()?.ID ?? 0;
            shopkeeper.ID = lastID + 1;
            Database.tbShopkeeper.Add(shopkeeper);
        }
    }
}
