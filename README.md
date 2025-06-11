# Usuários App

Sistema para cadastro de usuários com autenticação JWT, CRUD, e interface responsiva com Angular + Bootstrap.

---

## Estrutura do Projeto

- `frontend/` - Angular 17 SPA com Bootstrap 5
- `backend/` - ASP.NET Core 9 API REST com EF Core e SQLite

---

## Como Rodar o Projeto

### Backend

1. Acesse a pasta:
```bash
cd backend
```

2. Crie o banco e rode as migrations:
```bash
dotnet ef database update
```

3. Inicie a API:
```bash
dotnet run
```

A API estará acessível em: `http://localhost:5000`

### Frontend

1. Acesse a pasta:
```bash
cd frontend
```

2. Instale as dependências:
```bash
npm install
```

3. Inicie o projeto Angular:
```bash
ng serve
```

SPA estará disponível em: `http://localhost:4200`

---

## ⛳ Requisitos Atendidos

- [x] Login com usuário e senha (JWT)
- [x] CRUD completo de usuários (Angular + .NET)
- [x] Somente autenticado acessa rotas protegidas
- [x] Banco de dados relacional (SQLite)
- [x] EF Core para manipulação
- [x] Interface Bootstrap responsiva
- [x] Nenhum uso de scaffold

---

## 🔐 Login Padrão (via seed)

```
Usuário: admin
Senha: admin123
```

---

## 🔧 Tecnologias

- Angular 17
- ASP.NET Core 9
- Entity Framework Core
- SQLite
- JWT
- Bootstrap 5

---

## ✨ Autor

Juliano Ortiz Sarruf