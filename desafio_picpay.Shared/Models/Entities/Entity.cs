namespace desafio_picpay.Shared.Models.Entities
{
    public abstract class Entity
    {
        public int ID { get; set; }
        public EType Type { get; set; } = EType.None;

        public enum EType
        {
            None,
            Shopkeeper,
            User,
        }
    }
}
