using Barinak.Entity;

namespace Barinak.Data.Abstract
{
    public interface IUserRepository
    {
        IQueryable<User> Users { get; }
        void CreateUser(User user);

    }
}