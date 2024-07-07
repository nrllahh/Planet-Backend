using Planet.Domain.SharedKernel;
namespace Planet.Domain.Users
{
    public interface IUserDomainRepository : IDomainRepository<User>
    {
        Task<User> FindByEmailAsync(string email);
    }
}
