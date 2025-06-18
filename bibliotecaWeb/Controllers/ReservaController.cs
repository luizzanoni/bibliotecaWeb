using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Linq;
using BibliotecaMVC.Models;
using BibliotecaMVC.Data;

namespace BibliotecaMVC.Controllers
{
    public class ReservaController : Controller
    {
        public IActionResult Index()
        {
            return View(FakeDatabase.Livros);
        }

        [HttpGet]
        public IActionResult Reservar(int livroId)
        {
            int usuarioId = HttpContext.Session.GetInt32("UsuarioId") ?? 0;

            FakeDatabase.Reservas.Add(new Reserva
            {
                Id = FakeDatabase.Reservas.Count + 1,
                IdLivro = livroId,
                IdUsuario = usuarioId
            });

            return RedirectToAction("Index");
        }
    }
}
