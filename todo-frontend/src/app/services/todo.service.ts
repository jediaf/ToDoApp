// todo-frontend/src/app/services/todo.service.ts

import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ToDo } from '../models/todo.model';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class TodoService {
  private apiUrl = `${environment.apiUrl}/todo`;

  constructor(private http: HttpClient) {}

  getToDos(): Observable<ToDo[]> {
    return this.http.get<ToDo[]>(this.apiUrl);
  }

  getToDoById(id: number): Observable<ToDo> {
    return this.http.get<ToDo>(`${this.apiUrl}/${id}`);
  }

  createToDo(todo: ToDo): Observable<ToDo> {
    return this.http.post<ToDo>(this.apiUrl, todo);
  }

  updateToDo(id: number, todo: ToDo): Observable<any> {
    return this.http.put(`${this.apiUrl}/${id}`, todo);
  }

  deleteToDo(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
}
