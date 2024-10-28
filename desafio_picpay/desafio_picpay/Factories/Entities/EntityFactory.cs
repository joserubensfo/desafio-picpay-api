using desafio_picpay.Models.Entities;
using System.Text.Json;

namespace desafio_picpay.Factories.Entities
{
    public class EntityFactory : IEntityFactory
    {
        public Entity Create(Type typeEntity, JsonElement json)
        {
            try
            {
                if(typeEntity == typeof(User))
                {
                    return json.Deserialize<Shopkeeper>()!;
                }
                else if(typeEntity == typeof(Shopkeeper))
                {
                    return json.Deserialize<Shopkeeper>()!;
                }
                else
                {
                   throw new ArgumentException("Tipo de entidade inválido.");
                }
            }
            catch (JsonException ex)
            {
                throw new InvalidOperationException("Erro ao desserializar o JSON para a entidade especificada.", ex);
            }
        }
    }
}
