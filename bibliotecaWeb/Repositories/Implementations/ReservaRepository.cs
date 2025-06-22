using BibliotecaMVC.Data;
using BibliotecaMVC.Models;
using BibliotecaMVC.Repositories.Interfaces;

namespace BibliotecaMVC.Repositories.Implementations
{
    public class ReservaRepository : IReservaRepository
    {
        private readonly BibliotecaContext _context;

        public ReservaRepository(BibliotecaContext context)
        {
            _context = context;
        }

        public List<Reserva> GetAll() => _context.Reservas.ToList();

        public Reserva GetByLivroIdAndUsuarioId(int livroId, int usuarioId)
        {
            return _context.Reservas.FirstOrDefault(r => r.IdLivro == livroId && r.IdUsuario == usuarioId);
        }

        public void Add(Reserva reserva)
        {
            _context.Reservas.Add(reserva);
        }

        public void Remove(Reserva reserva)
        {
            _context.Reservas.Remove(reserva);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
