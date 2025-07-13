using BibliotecaMVC.Data;
using BibliotecaMVC.Models;
using BibliotecaMVC.Repositories.Implementations;
using BibliotecaMVC.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<BibliotecaContext>(options =>
    options.UseInMemoryDatabase("BibliotecaInMemoryDB"));

builder.Services.AddSession();

builder.Services.AddScoped<ILivroRepository, LivroRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IReservaRepository, ReservaRepository>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<BibliotecaContext>();

    context.Usuarios.AddRange(
        new Usuario { Id = 1, Nome = "admin", Senha = "admin", Admin = true },
        new Usuario { Id = 2, Nome = "user", Senha = "123", Admin = false }
    );

    context.Livros.AddRange(
        new Livro { Id = 1, Titulo = "O Hobbit", Autor = "Tolkien", Ano = 1937 },
        new Livro { Id = 2, Titulo = "Casmurro", Autor = "Machado", Ano = 1899 },
        new Livro { Id = 3, Titulo = "1984", Autor = "Orwell", Ano = 1949 },
        new Livro { Id = 4, Titulo = "Orgulho", Autor = "Austen", Ano = 1813 },
        new Livro { Id = 5, Titulo = "Príncipe", Autor = "Saint-Exupéry", Ano = 1943 },
        new Livro { Id = 6, Titulo = "Solidão", Autor = "García Márquez", Ano = 1967 },
        new Livro { Id = 7, Titulo = "Bichos", Autor = "Orwell", Ano = 1945 },
        new Livro { Id = 8, Titulo = "Harry Potter", Autor = "Rowling", Ano = 1997 },
        new Livro { Id = 9, Titulo = "Anel", Autor = "Tolkien", Ano = 1954 },
        new Livro { Id = 10, Titulo = "Crime", Autor = "Dostoiévski", Ano = 1866 },
        new Livro { Id = 11, Titulo = "Alquimista", Autor = "Coelho", Ano = 1988 }
);

    context.SaveChanges();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
