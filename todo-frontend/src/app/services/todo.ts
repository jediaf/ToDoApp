// todo-frontend/src/app/services/todo.service.ts
// ToDo API'si ile iletişim kuran servis.
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ToDo, CreateToDoDto, UpdateToDoDto } from '../models/todo.model'; // DTO'yu import et

@Injectable({
  providedIn: 'root', // Uygulama genelinde bu servisin tek bir örneği olmasını sağlar
})
export class TodoService {
  private apiUrl = 'http://localhost:8080/api/todo'; // Backend API adresiniz

  constructor(private http: HttpClient) {}

  // Tüm ToDo'ları getirir.
  getTodos(): Observable<ToDo[]> {
    return this.http.get<ToDo[]>(this.apiUrl);
  }

  // ID'ye göre ToDo getirir.
  getTodoById(id: number): Observable<ToDo> {
    return this.http.get<ToDo>(`${this.apiUrl}/${id}`);
  }

  // Yeni ToDo oluşturur.
  createTodo(todo: ToDo): Observable<ToDo> {
    return this.http.post<ToDo>(this.apiUrl, todo);
  }

  // ToDo günceller.
  updateTodo(id: number, todo: ToDo): Observable<any> {
    return this.http.put(`${this.apiUrl}/${id}`, todo);
  }

  // ToDo siler.
  deleteTodo(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
}
