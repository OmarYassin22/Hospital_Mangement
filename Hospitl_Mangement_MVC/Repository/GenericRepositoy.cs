using Hospitl_Mangement_MVC.Data;
using Hospitl_Mangement_MVC.Interface;
using Hospitl_Mangement_MVC.Models;

namespace Hospitl_Mangement_MVC.Repository
{
    public class GenericRepositoy<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly HospitalDbContext _context;

        public GenericRepositoy(HospitalDbContext context)
        {
            _context = context;
        }
        public int Add(T entity)
        {
            _context.Set<T>().Add(entity);
            return _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Remove(id);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IEnumerable<T> GetAll()
      => _context.Set<T>().ToList();

        public T GetById(int id)
      => _context.Set<T>().Find(id);

        public int Update(T entity)
        {
            _context.Update(entity);
            return _context.SaveChanges();
        }
    }
}
