using desafio_picpay.Models.Entities;

namespace desafio_picpay.Models.Transfers
{
    public class Transfer
    {
        public User Payer { get; set; }
        public User Payee { get; set; }
        public decimal Value { get; set; }

        public Transfer(User payer, User payee, decimal value)
        {
            Payer = payer;
            Payee = payee;
            Value = value;
        }
    }
}
