// todo-frontend/src/app/models/todo.model.ts
// ToDo modelini tanımlar.
import { Category } from './category.model'; // Category modelini import ediyoruz

export interface ToDo {
  id?: number; // ToDo ID'si, backend tarafından atanacağı için opsiyonel
  title: string; // Görev başlığı
  description?: string; // Görev açıklaması, opsiyonel
  isCompleted: boolean; // Görevin tamamlanma durumu
  createdAt?: Date; // Oluşturulma tarihi, backend tarafından atanacağı için opsiyonel
  categoryId?: number | null; // Görevin ait olduğu kategori ID'si, null olabilir
  category?: Category; // Kategori nesnesi, backend'den geldiğinde doldurulur
  categoryName?: string;
}
// Yeni bir ToDo oluşturulurken API'ye gönderilecek veriyi temsil eden DTO
export interface CreateToDoDto {
  title: string;
  description?: string;
  isCompleted: boolean;
  categoryId?: number | null;
}

// Mevcut bir ToDo güncellenirken API'ye gönderilecek veriyi temsil eden DTO
export interface UpdateToDoDto {
  title: string;
  description?: string;
  isCompleted: boolean;
  categoryId?: number | null;
}
