
using desafio_picpay.Models.Entities;

namespace desafio_picpay
{
    public static class StaticDataBase
    {
        public static List<Shopkeeper> tbShopkeeper { get; set; } = new List<Shopkeeper>();
        public static List<User> tbUser { get; set; } = new List<User>();
    }
}
