// todo-frontend/src/app/app.ts
// Ana uygulama bileşeni (Standalone).
import { Component } from '@angular/core';
import { CommonModule } from '@angular/common'; // ngIf, ngFor gibi direktifler için
import { TodoListComponent } from './components/todo-list/todo-list'; // TodoListComponent'i import ediyoruz

@Component({
  selector: 'app-root',
  standalone: true, // Bu bileşenin standalone olduğunu belirtir
  imports: [CommonModule, TodoListComponent], // Gerekli modülleri ve bileşenleri import eder
  templateUrl: './app.html', // HTML şablonu
  styleUrls: ['./app.scss'], // SCSS stil dosyası
})
export class AppComponent {
  title = 'todo-frontend'; // Uygulama başlığı
}
