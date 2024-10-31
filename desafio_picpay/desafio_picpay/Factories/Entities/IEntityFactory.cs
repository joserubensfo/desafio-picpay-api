using desafio_picpay.Shared.Models.Entities;
using System.Text.Json;

namespace desafio_picpay.Factories.Entities
{
    public interface IEntityFactory
    {
        public Entity Create(Type typeEntity, JsonElement json);
    }
}
