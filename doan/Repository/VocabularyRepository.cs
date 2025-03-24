using doan.Models;
using System.Collections.Generic;
using System.Linq;

namespace doan.Repository
{
    public class VocabularyRepository : IVocabularyRepository
    {
        private readonly ApplicationDbContext _context;
        public VocabularyRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<Bai01Model> GetAll()
        {
            return _context.Bai01.ToList();
        }
        public Bai01Model GetByID(int id)
        {
            return _context.Bai01.FirstOrDefault(v => v.Id == id);
        }

        public void Update(Bai01Model vocab)
        {
            _context.Bai01.Update(vocab);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}