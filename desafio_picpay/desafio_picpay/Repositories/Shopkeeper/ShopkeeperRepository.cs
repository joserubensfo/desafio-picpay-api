
using desafio_picpay.Models.Entities;

namespace desafio_picpay.Repositories.Shopkeeper
{
    public class ShopkeeperRepository : IShopkeeperRepository
    {
        public void Add(Models.Entities.Shopkeeper shopkeeper)
        {
            int lastID = StaticDataBase.tbShopkeeper.LastOrDefault()?.ID ?? 0;
            shopkeeper.ID = lastID + 1;

            StaticDataBase.tbShopkeeper.Add(shopkeeper);
        }
    }
}
