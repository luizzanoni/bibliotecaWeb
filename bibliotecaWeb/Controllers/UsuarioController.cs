using BibliotecaMVC.Data;
using BibliotecaMVC.Models;
using BibliotecaMVC.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

public class UsuarioController : Controller
{
    private readonly IUsuarioRepository _usuarioRepository;

    public UsuarioController(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public IActionResult Index()
    {
        var usuarios = _usuarioRepository.GetAll();
        return View(usuarios);
    }

    [HttpGet]
    public IActionResult Create() => View();

    [HttpPost]
    public IActionResult Create(Usuario usuario)
    {
        _usuarioRepository.Add(usuario);
        _usuarioRepository.Save();

        return RedirectToAction("Index");
    }
}
