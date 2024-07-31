using Barinak.Data.Abstract;
using Barinak.Entity;

namespace Barinak.Data.Concrete
{
    public class EfCommentRepository : ICommentRepository
    {
        private BarinakContext _context;
        public EfCommentRepository(BarinakContext context)
        {
            _context = context;
        }
        public IQueryable<Comment> Comments => _context.Comments;

        public void CreateComment(Comment comment)
        {
            _context.Comments.Add(comment);
            _context.SaveChanges();
        }
    }
}