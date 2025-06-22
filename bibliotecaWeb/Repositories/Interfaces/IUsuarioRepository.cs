using BibliotecaMVC.Models;

namespace BibliotecaMVC.Repositories.Interfaces
{
    public interface IUsuarioRepository
    {
        List<Usuario> GetAll();
        Usuario GetByCredentials(string nome, string senha);
        void Add(Usuario usuario);
        void Save();
    }
}

