// todo-frontend/src/app/components/todo-form/todo-form.ts
// ToDo ekleme ve düzenleme formu bileşeni.
import {
  Component,
  Input,
  Output,
  EventEmitter,
  OnInit,
  OnChanges,
  SimpleChanges,
} from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ToDo, CreateToDoDto, UpdateToDoDto } from '../../models/todo.model';
import { Category } from '../../models/category.model';
import { TodoService } from '../../services/todo.service'; // .service uzantısı bırakıldı, tsconfig ile yönetilecek
import { HttpErrorResponse } from '@angular/common/http'; // Hata yakalama için eklendi

@Component({
  selector: 'app-todo-form',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './todo-form.html',
  styleUrls: ['./todo-form.scss'],
})
export class TodoFormComponent implements OnInit, OnChanges {
  @Input() todo: ToDo | null = null;
  @Input() categories: Category[] = [];
  @Output() formSubmitted = new EventEmitter<void>();

  currentTodo: ToDo = {
    title: '',
    description: '',
    isCompleted: false,
    categoryId: null,
  };
  isEditMode: boolean = false;

  constructor(private todoService: TodoService) {}

  ngOnInit(): void {
    this.initializeForm();
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['todo']) {
      this.initializeForm();
    }
  }

  private initializeForm(): void {
    if (this.todo && this.todo.id) {
      this.currentTodo = { ...this.todo };
      this.isEditMode = true;
    } else {
      this.currentTodo = {
        title: '',
        description: '',
        isCompleted: false,
        categoryId: null,
      };
      this.isEditMode = false;
    }
    if (this.currentTodo.categoryId === undefined) {
      this.currentTodo.categoryId = null;
    }
  }

  onSubmit(): void {
    if (
      this.currentTodo.categoryId === undefined ||
      this.currentTodo.categoryId === null
    ) {
      this.currentTodo.categoryId = null;
    }

    if (this.isEditMode && this.currentTodo.id) {
      const updateDto: UpdateToDoDto = { ...this.currentTodo };
      this.todoService
        .updateToDo(this.currentTodo.id, this.currentTodo) // updateTodo olarak düzeltildi
        .subscribe({
          next: () => this.formSubmitted.emit(),
          error: (
            err: HttpErrorResponse // Hata tipi belirtildi
          ) => console.error('ToDo güncellenirken hata oluştu:', err),
        });
    } else {
      const createDto: CreateToDoDto = {
        title: this.currentTodo.title,
        description: this.currentTodo.description,
        isCompleted: this.currentTodo.isCompleted,
        categoryId: this.currentTodo.categoryId,
      };
      this.todoService.createToDo(this.currentTodo).subscribe({
        // createTodo olarak düzeltildi
        next: () => this.formSubmitted.emit(),
        error: (
          err: HttpErrorResponse // Hata tipi belirtildi
        ) => console.error('ToDo oluşturulurken hata oluştu:', err),
      });
    }
  }

  cancel(): void {
    this.formSubmitted.emit();
  }
}
