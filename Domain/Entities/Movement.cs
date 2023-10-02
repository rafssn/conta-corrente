using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Movement
    {
        //ORM
        private Movement() { }
        public static Movement Create([Required] MovementType type, [Required] decimal value, [Required] Account account)
        {
            if(value <= 0)
                throw new ArgumentOutOfRangeException();

            return new Movement(type, value, account);
        }

        private Movement(MovementType type, decimal value, Account account)
        {
            Type = type;
            Value = value;
            Account = account;
            AccountId = account.Id;
        }

        public int Id { get; }
        public MovementType Type { get; }
        public decimal Value { get; }
        public int AccountId { get; }
        public virtual Account Account { get; }
    }

    public enum MovementType
    {
        Set = 0,    //Depositar
        Get = 1     //Sacar
    }
}
