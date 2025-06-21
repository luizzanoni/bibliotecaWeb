using BibliotecaMVC.Models;

namespace BibliotecaMVC.Repositories.Interfaces
{
    public interface ILivroRepository
    {
        List<Livro> GetAll();
        Livro GetById(int id);
        void Add(Livro livro);
        void Remove(Livro livro);
        void Save();
    }
}
