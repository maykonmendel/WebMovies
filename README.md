# WebMovies

![WebMovies](https://ibb.co/TPYqMBJ)

## Tecnologias e práticas utilizadas
- ASP.NET Core com .NET 6
- Entity Framework Core
- SQL Server
- Swagger
- Injeção de Dependência
- Programação Orientada a Objetos
- Padrão Repository
- Clean Code

## Funcionalidades
- Cadastro, Edição, Remoção e Listagem de Diretores
- Cadastro, Edição, Remoção e Listagem de Filmes

## Como executar o projeto

**Acessar o terminal com direitos administrativos**

1. Clonar o projeto do Github

```
git@github.com:maykonmendel/WebMovies.git

```

2. Acessar a pasta WebMovies/WebMovies e restaurar os pacotes do projeto.
   
```
dotnet restore
dotnet build

```

3. Criar no SQL Server um novo usuário e senha com direitos de administrador:

```
usuário: developer
senha: MyPass@word
```

3. Criar um novo banco de dados com o EF Core:
   
```
dotnet ef database update
```

4. Executar o projeto:

```
dotnet run
```

5. Abrir o navegador e acessar através da porta indica pelo dotnet run:

```
https://localhost:{port}/swagger/index.html
```
