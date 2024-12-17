ToDoList API - Gerenciamento de Tarefas
Descrição

Este projeto é uma API REST para gerenciar tarefas e suas respectivas listas, permitindo o cadastro de usuários e login. A aplicação oferece as funcionalidades de CRUD (Criar, Ler, Atualizar e Deletar) tanto para as tarefas quanto para as listas de tarefas. Além disso, ela inclui um sistema de autenticação com tokens JWT, onde as senhas dos usuários são armazenadas de forma segura utilizando o algoritmo de hash Argon2.
Funcionalidades

    CRUD Assignment: Gerenciamento das tarefas.
    CRUD AssignmentList: Gerenciamento das listas de tarefas.
    CRUD User: Gerenciamento dos usuários.
    Busca por email e nome: Busca avançada de usuários.
    Token de autenticação: Sistema de autenticação utilizando JWT.
    Senhas salvas via hash Argon2: Proteção das senhas dos usuários utilizando Argon2.

Tecnologias utilizadas

    C#: Linguagem de programação utilizada.
    .NET 8: Framework para desenvolvimento da API.
    Entity Framework Core 8: ORM para acesso ao banco de dados.
    MySQL: Banco de dados relacional utilizado.
    AutoMapper: Biblioteca para mapeamento de objetos.
    FluentValidation: Biblioteca para validação de objetos.
    ScottBrady91.AspNetCore.Identity.Argon2PasswordHasher: Biblioteca para aplicar hash Argon2 nas senhas dos usuários.

Como Executar
Pré-requisitos

    .NET 8
    MySQL
    Ferramenta de gerenciamento de pacotes NuGet

Instalação

    Clone o repositório:

git clone git@github.com:Esams5/ToDoList.git
cd todolist-api

Restaure as dependências:

dotnet restore

Configure o banco de dados MySQL e as conexões no arquivo appsettings.json:

"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=todolist;User=root;Password=yourpassword;"
}

Aplique as migrações para criar o banco de dados:

dotnet ef database update

Execute a API:

    dotnet run

A API estará disponível em http://localhost:5000 por padrão.
Testes

A aplicação possui endpoints para testar todas as funcionalidades, incluindo o CRUD de tarefas, listas de tarefas, usuários e autenticação. A documentação completa pode ser acessada através do Swagger, que está disponível na rota /swagger após a execução da aplicação.


