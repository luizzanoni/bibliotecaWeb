using BibliotecaMVC.Data;
using BibliotecaMVC.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

public class LoginController : Controller
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly ILivroRepository _livroRepository;
    public LoginController(IUsuarioRepository usuarioRepository, ILivroRepository livroRepository)
    {
        _usuarioRepository = usuarioRepository;
        _livroRepository = livroRepository;
    }

    [HttpGet]
    public IActionResult Index()
    {
        // Exibe o formulário de login
        return View();
    }

    [HttpPost]
    public IActionResult Index(string nome, string senha)
    {
        var usuario = _usuarioRepository.GetByCredentials(nome, senha);


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

        var livros = _livroRepository.GetAll();
        return View("DashboardUsuario", livros);
    }


    public IActionResult Logoff()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }
}
