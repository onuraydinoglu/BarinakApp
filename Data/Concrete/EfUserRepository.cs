using Barinak.Data.Abstract;
using Barinak.Entity;

namespace Barinak.Data.Concrete
{
    public class EfUserRepository : IUserRepository
    {
        private BarinakContext _context;
        public EfUserRepository(BarinakContext context)
        {
            _context = context;
        }
        public IQueryable<User> Users => _context.Users;

        public void CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}