// todo-frontend/src/main.ts
// Angular uygulamasının başlangıç noktası.
import { bootstrapApplication } from '@angular/platform-browser';
import { appConfig } from './app/app.config';
import { AppComponent } from './app/app'; // Ana AppComponent'i import ediyoruz

bootstrapApplication(AppComponent, appConfig).catch((err) =>
  console.error(err)
);
