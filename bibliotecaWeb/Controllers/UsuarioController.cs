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

    public IActionResult Index(string sortOrder)
    {
        int? usuarioId = HttpContext.Session.GetInt32("UsuarioId");
        if (usuarioId == null)
            return RedirectToAction("Index", "Login");

        var usuarios = _usuarioRepository.GetAll();

        usuarios = sortOrder switch
        {
            "nome_desc" => usuarios.OrderByDescending(u => u.Nome).ToList(),
            "tipo" => usuarios.OrderBy(u => u.Admin).ToList(),
            "tipo_desc" => usuarios.OrderByDescending(u => u.Admin).ToList(),
            _ => usuarios.OrderBy(u => u.Nome).ToList(), // Nome crescente
        };

        ViewBag.NomeSortParam = sortOrder == "nome" ? "nome_desc" : "nome";
        ViewBag.TipoSortParam = sortOrder == "tipo" ? "tipo_desc" : "tipo";
        ViewBag.CurrentSort = sortOrder;

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
