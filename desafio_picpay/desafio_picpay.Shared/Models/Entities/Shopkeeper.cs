namespace desafio_picpay.Shared.Models.Entities
{
    public class Shopkeeper : User
    {
        public Shopkeeper(string name, string surName, string cpf, string email, string password) : base(name, surName, cpf, email, password)
        {
            Type = EType.Shopkeeper;
        }

        public Shopkeeper() : base()
        {
            Type = EType.Shopkeeper;
        }
    }
}
