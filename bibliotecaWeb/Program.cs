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
    new Livro { Id = 1, Titulo = "O Hobbit", Autor = "J.R.R. Tolkien", Ano = 1937 },
    new Livro { Id = 2, Titulo = "Dom Casmurro", Autor = "Machado de Assis", Ano = 1899 },
    new Livro { Id = 3, Titulo = "1984", Autor = "George Orwell", Ano = 1949 },
    new Livro { Id = 4, Titulo = "Orgulho e Preconceito", Autor = "Jane Austen", Ano = 1813 },
    new Livro { Id = 5, Titulo = "O Pequeno Pr ncipe", Autor = "Antoine de Saint-Exup ry", Ano = 1943 },
    new Livro { Id = 6, Titulo = "Cem Anos de Solid o", Autor = "Gabriel Garc a M rquez", Ano = 1967 },
    new Livro { Id = 7, Titulo = "A Revolu  o dos Bichos", Autor = "George Orwell", Ano = 1945 },
    new Livro { Id = 8, Titulo = "Harry Potter e a Pedra Filosofal", Autor = "J.K. Rowling", Ano = 1997 },
    new Livro { Id = 9, Titulo = "O Senhor dos An is: A Sociedade do Anel", Autor = "J.R.R. Tolkien", Ano = 1954 },
    new Livro { Id = 10, Titulo = "Crime e Castigo", Autor = "Fi dor Dostoi vski", Ano = 1866 },
    new Livro { Id = 11, Titulo = "O Alquimista", Autor = "Paulo Coelho", Ano = 1988 }
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
