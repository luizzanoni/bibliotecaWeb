using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Linq;
using BibliotecaMVC.Models;
using BibliotecaMVC.Data;

public class UsuarioController : Controller
{
    public IActionResult Index() => View(FakeDatabase.Usuarios);

    [HttpGet]
    public IActionResult Create() => View();

    [HttpPost]
    public IActionResult Create(Usuario usuario)
    {
        usuario.Id = FakeDatabase.Usuarios.Max(u => u.Id) + 1;
        FakeDatabase.Usuarios.Add(usuario);
        return RedirectToAction("Index");
    }
}
