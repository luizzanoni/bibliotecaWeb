using BibliotecaMVC.Data;
using BibliotecaMVC.Models;
using BibliotecaMVC.Repositories.Interfaces;

namespace BibliotecaMVC.Repositories.Implementations
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly BibliotecaContext _context;

        public UsuarioRepository(BibliotecaContext context)
        {
            _context = context;
        }

        public List<Usuario> GetAll() => _context.Usuarios.ToList();

        public Usuario GetByCredentials(string nome, string senha)
        {
            return _context.Usuarios.FirstOrDefault(u => u.Nome == nome && u.Senha == senha);
        }

        public void Add(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }

}
