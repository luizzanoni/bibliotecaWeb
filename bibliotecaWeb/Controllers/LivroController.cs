using BibliotecaMVC.Data;
using BibliotecaMVC.Models;
using BibliotecaMVC.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaMVC.Controllers
{
    public class LivroController : Controller
    {
        private readonly ILivroRepository _livroRepository;

        public LivroController(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var livros = _livroRepository.GetAll();
            return View(livros);
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var livro = _livroRepository.GetById(id);
            if (livro != null)
            {
                _livroRepository.Remove(livro);
                _livroRepository.Save();
            }
            return RedirectToAction("Index", "Reserva");
        }

        [HttpPost]
        public IActionResult Create(Livro livro)
        {
            _livroRepository.Add(livro);
            _livroRepository.Save();

            return RedirectToAction("Index", "Reserva");
        }
    }
}
