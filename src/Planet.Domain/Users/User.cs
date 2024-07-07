using Planet.Domain.SharedKernel;

namespace Planet.Domain.Users
{
    public sealed class User : Entity, IAggregateRoot
    {
        public Email Email { get; private set; }
        public string Password { get; private set; }
        public string Salt { get; private set; }
        public FirstName FirstName { get; private set; }
        public LastName LastName { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public string RefreshToken { get; private set; }
        public DateTime? TokenExpireDate { get; private set; }
        public bool IsActive { get; private set; }

        private User() : base(Guid.Empty) { }

        private User(
            Guid id,
            Email email,
            string password,
            FirstName firstName,
            LastName lastName,
            DateTime createdDate,
            bool isActive) : base(id)
        {
            Email = email;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            CreatedDate = createdDate;
            IsActive = isActive;
        }
        private User(
            Guid id,
            Email email,
            string password,
            string salt,
            FirstName firstName,
            LastName lastName,
            DateTime createdDate) : base(id)
        {
            Email = email;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            CreatedDate = createdDate;
            Password = password;
            Salt = salt;
            IsActive = true;
        }

        public static User Create(
            Guid id,
            Email email,
            string password,
            string salt,
            FirstName firstName,
            LastName lastName,
            DateTime createdDate)
        {
            return new User(id, email, password, salt, firstName, lastName, createdDate);
        }

        public static User Create(
            Guid id,
            Email email,
            string password,
            FirstName firstName,
            LastName lastName,
            DateTime createdDate,
            bool isActive)
        {
            return new User(id, email, password, firstName, lastName, createdDate, isActive);
        }

        public void ChangeActivity(bool activity)
        {
            IsActive = activity;
        }

        public void SignIn(string refreshToken, DateTime tokenExpireDate)
        {
            RefreshToken = refreshToken;
            TokenExpireDate = tokenExpireDate;
        }

        public void ChangePassword(string newPasswordHash, string newSalt)
        {
            Password = newPasswordHash;
            Salt = newSalt;
        }


    }
}
