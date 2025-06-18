using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Linq;
using BibliotecaMVC.Models;
using BibliotecaMVC.Data;

public class LoginController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        // Exibe o formulário de login
        return View();
    }

    [HttpPost]
    public IActionResult Index(string nome, string senha)
    {
        var usuario = FakeDatabase.Usuarios.FirstOrDefault(u => u.Nome == nome && u.Senha == senha);
        if (usuario != null)
        {
            HttpContext.Session.SetString("NomeUsuario", usuario.Nome);
            HttpContext.Session.SetString("TipoUsuario", usuario.Admin ? "Admin" : "Usuario");
            HttpContext.Session.SetInt32("UsuarioId", usuario.Id);
            HttpContext.Session.SetString("UsuarioNome", usuario.Nome);

            return RedirectToAction("Dashboard");
        }

        ViewBag.Erro = "Usuário ou senha inválidos.";
        return View();
    }

    public IActionResult Dashboard()
    {
        var tipo = HttpContext.Session.GetString("TipoUsuario");
        if (string.IsNullOrEmpty(tipo))
            return RedirectToAction("Index");

        if (tipo == "Admin")
            return View("DashboardAdmin");

        var livros = FakeDatabase.Livros;
        return View("DashboardUsuario", livros);
    }


    public IActionResult Logoff()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }
}
