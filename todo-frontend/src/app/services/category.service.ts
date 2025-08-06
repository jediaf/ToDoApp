// todo-frontend/src/app/services/category.service.ts
// Kategori API'si ile iletişim kuran servis.
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Category } from '../models/category.model'; // Modeli doğru yoldan import et

@Injectable({
  providedIn: 'root', // Uygulama genelinde bu servisin tek bir örneği olmasını sağlar
})
export class CategoryService {
  private apiUrl = 'http://localhost:8080/api/category'; // Backend API adresiniz

  constructor(private http: HttpClient) {}

  // Tüm kategorileri getirir.
  getCategories(): Observable<Category[]> {
    return this.http.get<Category[]>(this.apiUrl);
  }

  // ID'ye göre kategori getirir.
  getCategoryById(id: number): Observable<Category> {
    return this.http.get<Category>(`${this.apiUrl}/${id}`);
  }

  // Yeni kategori oluşturur.
  createCategory(category: Category): Observable<Category> {
    return this.http.post<Category>(this.apiUrl, category);
  }

  // Kategori günceller.
  updateCategory(id: number, category: Category): Observable<any> {
    return this.http.put(`${this.apiUrl}/${id}`, category);
  }

  // Kategori siler.
  deleteCategory(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
}
