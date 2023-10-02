using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Account
    {
        //ORM
        private Account() { }
        public static Account Create([Required] User user)
        {
            return new Account(user);
        }

        public static Account UpdateBalance(Account account, Movement movement)
        {
            if (movement.Type is MovementType.Get && account.Balance < movement.Value)
                throw new InvalidOperationException("Value bigger than balance. Try a new one.");

            switch(movement.Type)
            {
                case MovementType.Set:
                    account.Balance += movement.Value;
                    break;
                case MovementType.Get:
                    account.Balance -= movement.Value;
                    break;
            };

            return account;
        }

        private Account(User user)
        {
            UserId = user.Id;
            User = user;
            Movements = new List<Movement>();
        }

        public int Id { get; }
        public int UserId { get; }
        public decimal Balance { get; private set; }
        public virtual User User { get; }
        public virtual IList<Movement> Movements { get; }
    }
}
