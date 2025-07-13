using BibliotecaMVC.Data;
using BibliotecaMVC.Models;
using BibliotecaMVC.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaMVC.Controllers
{
    public class ReservaController : Controller
    {
        private const int TamanhoPagina = 5;
        private readonly ILivroRepository _livroRepository;
        private readonly IReservaRepository _reservaRepository;

        public ReservaController(ILivroRepository livroRepository, IReservaRepository reservaRepository)
        {
            _livroRepository = livroRepository;
            _reservaRepository = reservaRepository;
        }

        public IActionResult Index(string filtro, int pagina = 1)
        {
            int? usuarioId = HttpContext.Session.GetInt32("UsuarioId");
            if (usuarioId == null)
                return RedirectToAction("Index", "Login");

            var livrosDisponiveis = FiltrarLivrosDisponiveis(usuarioId.Value, filtro);

            var totalLivros = livrosDisponiveis.Count();
            var livrosPaginados = livrosDisponiveis
                .Skip((pagina - 1) * TamanhoPagina)
                .Take(TamanhoPagina)
                .ToList();

            ViewBag.PaginaAtual = pagina;
            ViewBag.TotalPaginas = (int)Math.Ceiling(totalLivros / (double)TamanhoPagina);
            ViewBag.Filtro = filtro;

            return View(livrosPaginados);
        }

        [HttpPost]
        public IActionResult Reservar(int livroId)
        {
            int? usuarioId = HttpContext.Session.GetInt32("UsuarioId");
            if (usuarioId == null)
                return RedirectToAction("Index", "Login");

            var livro = _livroRepository.GetById(livroId);

            if (livro != null && !livro.Reservado)
            {
                livro.Reservado = true;
                livro.IdUsuarioReserva = usuarioId;

                _reservaRepository.Add(new Reserva
                {
                    IdLivro = livroId,
                    IdUsuario = usuarioId.Value
                });

                _reservaRepository.Save();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult CancelarReserva(int livroId)
        {
            int? usuarioId = HttpContext.Session.GetInt32("UsuarioId");
            if (usuarioId == null)
                return RedirectToAction("Index", "Login");

            var livro = _livroRepository.GetById(livroId);
            var reserva = _reservaRepository.GetByLivroIdAndUsuarioId(livroId, usuarioId.Value);

            if (livro != null && reserva != null)
            {
                livro.Reservado = false;
                livro.IdUsuarioReserva = null;

                _reservaRepository.Remove(reserva);
                _reservaRepository.Save();
            }

            return RedirectToAction("Index");
        }

        private IEnumerable<Livro> FiltrarLivrosDisponiveis(int usuarioId, string filtro)
        {
            var livros = _livroRepository
                .GetAll()
                .Where(l => !l.Reservado || l.IdUsuarioReserva == usuarioId);

            if (!string.IsNullOrWhiteSpace(filtro))
                livros = livros.Where(l => l.Titulo.Contains(filtro, StringComparison.OrdinalIgnoreCase));

            return livros;
        }
    }
}
