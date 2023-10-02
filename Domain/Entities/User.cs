using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class User
    {
        //ORM
        private User() { }
        public User([Required] string email, [Required] string name, [Required] string passwordHash)
        {
            Email = email;
            Name = name;
            PasswordHash = passwordHash;
            Accounts = new List<Account>();
        }

        public int Id { get; }
        public string Email { get; }
        public string Name { get; }
        public string PasswordHash { get; }
        public virtual IList<Account> Accounts { get; }
    }
}
