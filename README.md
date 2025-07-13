# 📚 Biblioteca Web

Aplicação web ASP.NET Core para gerenciar livros, usuários e reservas em uma biblioteca. O sistema permite o cadastro de livros, gerenciamento de usuários e controle de reservas, utilizando o padrão MVC com repositórios e Entity Framework Core.

## 🚀 Funcionalidades

- Cadastro, edição e exclusão de livros
- Gerenciamento de usuários
- Reservas de livros
- Interface Web amigável
- Persistência com Entity Framework Core

## 🛠️ Tecnologias Utilizadas

- ASP.NET Core MVC
- Entity Framework Core
- Razor Pages
- C#
- SQL Server / SQLite

## ⚙️ Estrutura do Projeto

```
bibliotecaWeb/
│
├── Controllers/        # Lógicas de controle para livros, usuários, reservas
├── Models/             # Entidades do domínio (Livro, Usuario, Reserva)
├── Data/               # Contexto do banco de dados (BibliotecaContext)
├── Repositories/       # Interfaces e implementações dos repositórios
├── Views/              # Arquivos de interface Razor (não listados aqui)
├── Program.cs          # Ponto de entrada da aplicação
├── bibliotecaWeb.csproj
```

## 🖥️ Como Rodar o Projeto

### ✔️ Pré-requisitos

- [.NET SDK 7.0 ou superior](https://dotnet.microsoft.com/en-us/download)
- Um editor como Visual Studio, Rider ou VS Code

---

### ▶️ Executando no Windows

```bash
# 1. Navegue até a pasta do projeto
cd bibliotecaWeb/bibliotecaWeb

# 2. Restaure os pacotes NuGet
dotnet restore

# 3. Rode a aplicação
dotnet run

# 4. Acesse no navegador
http://localhost:5000
```

---

### 🐧 Executando no Linux

```bash
# 1. Vá até o diretório do projeto
cd bibliotecaWeb/bibliotecaWeb

# 2. Restaure as dependências
dotnet restore

# 3. Execute o projeto
dotnet run

# 4. Acesse via navegador
http://localhost:5000
```

> ⚠️ No Linux, verifique se você tem permissões de execução e se o SDK .NET está corretamente instalado via Snap, APT ou script oficial.

---

## 🗃️ Banco de Dados e Usuários

A aplicação utiliza **Entity Framework Core** para gerenciamento do banco de dados. O banco é criado automaticamente **em tempo de execução** ao iniciar o projeto. Não é necessário rodar comandos de migração manualmente.

> ⚠️ **Importante:** Sempre que o projeto for parado e iniciado novamente no Visual Studio ou VS Code, o banco será recriado com sua estrutura original.

### 👤 Usuários Predefinidos

Para facilitar os testes iniciais, dois usuários estão disponíveis por padrão:

- **Administrador**
  - Usuário: `admin`
  - Senha: `admin`

- **Usuário Comum**
  - Usuário: `user`
  - Senha: `123`