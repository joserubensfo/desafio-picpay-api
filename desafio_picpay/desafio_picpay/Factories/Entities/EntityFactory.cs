using desafio_picpay.Shared.Models.Entities;
using System.Text.Json;

namespace desafio_picpay.Factories.Entities
{
    public class EntityFactory : IEntityFactory
    {
        public Entity Create(Type typeEntity, JsonElement json)
        {
            if (typeEntity == typeof(User))
            {
                return json.Deserialize<User>()!;
            }
            else if (typeEntity == typeof(Shopkeeper))
            {
                return json.Deserialize<Shopkeeper>()!;
            }
            else
            {
                throw new ArgumentException("Incorrect user type.");
            }
        }
    }
}
