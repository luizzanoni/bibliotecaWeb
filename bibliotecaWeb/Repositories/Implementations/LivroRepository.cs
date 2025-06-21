using BibliotecaMVC.Data;
using BibliotecaMVC.Models;
using BibliotecaMVC.Repositories.Interfaces;

namespace BibliotecaMVC.Repositories.Implementations
{
    public class LivroRepository : ILivroRepository
    {
        private readonly BibliotecaContext _context;

        public LivroRepository(BibliotecaContext context)
        {
            _context = context;
        }

        public List<Livro> GetAll() => _context.Livros.ToList();

        public Livro GetById(int id) => _context.Livros.Find(id);

        public void Add(Livro livro)
        {
            _context.Livros.Add(livro);
        }

        public void Remove(Livro livro)
        {
            _context.Livros.Remove(livro);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
