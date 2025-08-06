// todo-frontend/src/app/app.config.ts
// Uygulama genelindeki servisleri ve sağlayıcıları yapılandırır.
import { ApplicationConfig } from '@angular/core';
import { provideRouter } from '@angular/router';
import { provideHttpClient } from '@angular/common/http'; // HttpClientModule yerine provideHttpClient kullanırız

import { routes } from './app.routes'; // app.routes.ts dosyasından rotaları alır

export const appConfig: ApplicationConfig = {
  providers: [
    provideRouter(routes), // Router servisini sağlar
    provideHttpClient(), // HttpClient servisini sağlar
  ],
};
