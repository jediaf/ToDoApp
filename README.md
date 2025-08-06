# ✅ Full-Stack To-Do List App

A full-stack web application built as part of a 4-week summer internship project at Ones Technology. This To-Do List app enables users to manage their tasks efficiently using a modern tech stack and clean user interface.

---

## 🚀 Tech Stack

- **Frontend**: Angular (SCSS)
- **Backend**: ASP.NET Core Web API (.NET 8)
- **Database**: SQLite
- **Containerization**: Docker + Docker Compose

---

## 🌟 Features

- Add, update, delete to-do tasks
- Categorize tasks and group them by category
- Mark tasks as completed or pending
- Responsive, modern UI built with Angular
- Dockerized for cross-platform development and deployment

---

## 📁 Project Structure

ToDoApp/
│
├── ToDoApp.Api/ # ASP.NET Core Web API
│ ├── Controllers/
│ ├── Data/
│ ├── Migrations/
│ └── appsettings.json
│
├── ToDoApp.Core/ # Shared domain models
│
├── ToDoApp.Infrastructure/ # EF Core DbContext and Repositories
│
├── todo-frontend/ # Angular Frontend Application
│ └── src/app/
│ ├── components/
│ ├── models/
│ └── services/
│
├── data/ # SQLite database mount folder
├── docker-compose.yml # Multi-container orchestration
├── Dockerfile # Backend image
└── README.md

## ⚙️ Getting Started

### Prerequisites

- [Docker](https://www.docker.com/)
- [Docker Compose](https://docs.docker.com/compose/)

> ✅ No need to install .NET SDK or Node.js locally – all runs inside containers!

---

### 🔧 Setup Instructions

```bash
git clone https://github.com/jediaf/ToDoApp.git
cd ToDoApp
docker compose up --build
⚠️ Troubleshooting
If the SQLite database file is not created:
Ensure the data/ folder exists at the root
Check appsettings.json → Data Source=./data/todo.db
To reset:
Delete data/todo.db
Re-run migrations using:
dotnet ef database update --project ToDoApp.Infrastructure --startup-project ToDoApp.Api
##📄 License
This project was developed for educational purposes as part of a university summer internship.
