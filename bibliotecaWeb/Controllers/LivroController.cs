using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Linq;
using BibliotecaMVC.Models;
using BibliotecaMVC.Data;

namespace BibliotecaMVC.Controllers
{
    public class LivroController : Controller
    {
        private static List<Livro> livros = new List<Livro>();

        [HttpGet]
        public IActionResult Index() => View(livros);

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var livro = FakeDatabase.Livros.FirstOrDefault(l => l.Id == id);
            if (livro != null)
            {
                FakeDatabase.Livros.Remove(livro);
            }
            return RedirectToAction("Index", "Reserva");
        }

        [HttpPost]
        public IActionResult Create(Livro livro)
        {
            livro.Id = FakeDatabase.Livros.Max(l => l.Id) + 1;
            FakeDatabase.Livros.Add(livro);
            return RedirectToAction("Index", "Reserva");
        }
    }
}
