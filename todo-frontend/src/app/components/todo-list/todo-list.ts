// todo-frontend/src/app/components/todo-list/todo-list.ts
// ToDo listesini ve kategorilere göre gruplamayı yöneten bileşen.
import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common'; // ngIf, ngFor, date pipe için
import { TodoService } from '../../services/todo';
import { CategoryService } from '../../services/category';
import { ToDo } from '../../models/todo.model';
import { Category } from '../../models/category.model';
import { TodoFormComponent } from '../todo-form/todo-form'; // Standalone bileşeni import ediyoruz
import { HttpErrorResponse } from '@angular/common/http'; // Hata yakalama için eklendi

@Component({
  selector: 'app-todo-list',
  standalone: true, // Bu bileşenin standalone olduğunu belirtir
  imports: [CommonModule, TodoFormComponent], // Gerekli modülleri ve bileşenleri import eder
  templateUrl: './todo-list.html', // HTML şablonu
  styleUrls: ['./todo-list.scss'], // SCSS stil dosyası
})
export class TodoListComponent implements OnInit {
  todos: ToDo[] = [];
  categories: Category[] = [];
  selectedTodo: ToDo | null = null;
  showForm: boolean = false;
  groupedTodos: { [key: string]: ToDo[] } = {}; // Kategorilere göre gruplanmış ToDo'lar

  constructor(
    private todoService: TodoService,
    private categoryService: CategoryService
  ) {}

  ngOnInit(): void {
    this.loadCategories(); // Kategorileri yükle
    this.loadTodos(); // ToDo'ları yükle
  }

  // Tüm kategorileri backend'den yükler.
  loadCategories(): void {
    this.categoryService.getCategories().subscribe((data) => {
      this.categories = data;
    });
  }

  // Tüm ToDo'ları backend'den yükler ve kategorilere göre gruplar.
  loadTodos(): void {
    this.todoService.getTodos().subscribe((data) => {
      this.todos = data;
      this.groupTodosByCategory(); // ToDo'ları kategorilere göre grupla
    });
  }

  // ToDo'ları kategorilere göre grupla ve sırala (güncellenmiş versiyon)
  groupTodosByCategory(): void {
    this.groupedTodos = {};
    const uncategorizedKey = 'Uncategorized';

    this.todos.forEach((todo) => {
      let categoryName = uncategorizedKey;

      if (todo.category?.name) {
        categoryName = todo.category.name;
      } else if (todo.categoryId) {
        const matched = this.categories.find((c) => c.id === todo.categoryId);
        if (matched) {
          categoryName = matched.name;
        }
      }

      if (!this.groupedTodos[categoryName]) {
        this.groupedTodos[categoryName] = [];
      }
      this.groupedTodos[categoryName].push(todo);
    });

    const sortedKeys = Object.keys(this.groupedTodos).sort((a, b) => {
      if (a === uncategorizedKey) return 1;
      if (b === uncategorizedKey) return -1;
      return a.localeCompare(b);
    });

    const sortedGroupedTodos: { [key: string]: ToDo[] } = {};
    sortedKeys.forEach((key) => {
      sortedGroupedTodos[key] = this.groupedTodos[key].sort((a, b) => {
        if (a.isCompleted !== b.isCompleted) return a.isCompleted ? 1 : -1;
        return (
          new Date(b.createdAt!).getTime() - new Date(a.createdAt!).getTime()
        );
      });
    });

    this.groupedTodos = sortedGroupedTodos;
  }

  // Bir ToDo öğesini düzenlemek için formu açar.
  editTodo(todo: ToDo): void {
    this.selectedTodo = { ...todo };
    this.showForm = true;
  }

  // Bir ToDo öğesini siler.
  deleteTodo(id: number | undefined): void {
    if (id) {
      this.todoService.deleteTodo(id).subscribe(() => {
        this.loadTodos();
      });
    }
  }

  // Bir ToDo öğesinin tamamlanma durumunu değiştirir.
  toggleCompleted(todo: ToDo): void {
    if (todo.id) {
      todo.isCompleted = !todo.isCompleted;
      this.todoService.updateTodo(todo.id, todo).subscribe(() => {
        this.groupTodosByCategory();
      });
    }
  }

  // Form gönderildiğinde veya iptal edildiğinde çağrılır, formu kapatır ve listeyi günceller.
  onFormSubmitted(): void {
    this.showForm = false;
    this.selectedTodo = null;
    this.loadTodos();
  }

  // Yeni bir ToDo eklemek için formu açar.
  addNewTodo(): void {
    this.selectedTodo = {
      title: '',
      description: '',
      isCompleted: false,
      categoryId: null,
    };
    this.showForm = true;
  }

  // Gruplanmış ToDo'ların anahtarlarını (kategori isimlerini) döner.
  getCategoryKeys(): string[] {
    return Object.keys(this.groupedTodos);
  }
}
