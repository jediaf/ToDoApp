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
├── ToDoApp.Api/               # ASP.NET Core Web API
│   ├── Controllers/           # API endpoints (ToDo & Category)
│   ├── Data/                  # Database configuration (DbContext)
│   ├── Migrations/            # EF Core migrations
│   ├── Program.cs             # Application entry point
│   └── appsettings.json       # API configuration
│
├── ToDoApp.Core/              # Domain models and interfaces
│   ├── Models/                # ToDo.cs, Category.cs
│   └── Interfaces/            # IToDoService, IRepository, etc.
│
├── ToDoApp.Infrastructure/   # EF Core implementation layer
│   ├── Repositories/          # Data access logic
│   └── Services/              # Business logic implementation
│
├── todo-frontend/             # Angular Frontend Application
│   ├── src/
│   │   ├── app/
│   │   │   ├── components/    # todo-list & todo-form components
│   │   │   ├── models/        # ToDo and Category models
│   │   │   └── services/      # API communication services
│   │   └── index.html         # Main HTML page
│   └── angular.json           # Angular config file
│
├── data/                      # SQLite DB volume (todo.db)
│
├── docker-compose.yml         # Docker multi-container orchestration
├── Dockerfile                 # Backend Docker image
└── README.md                  # Project documentation


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
## 🖼️ Screenshots
### 📌 Homepage
<img width="1620" height="1496" alt="To-Do App" src="https://github.com/user-attachments/assets/a675b509-83c3-4fde-ae04-fe6a672676af" />
### ➕ Add New Task
<img width="1620" height="1496" alt="To-Do App" src="https://github.com/user-attachments/assets/fbac5b36-4644-4ae2-b386-f2bd3f432347" />
