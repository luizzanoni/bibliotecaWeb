using BibliotecaMVC.Models;

namespace BibliotecaMVC.Repositories.Interfaces
{
    public interface IReservaRepository
    {
        List<Reserva> GetAll();
        Reserva GetByLivroIdAndUsuarioId(int livroId, int usuarioId);
        void Add(Reserva reserva);
        void Remove(Reserva reserva);
        void Save();
    }
}
