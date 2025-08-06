# Build aşaması
FROM node:20-alpine as build
WORKDIR /app
COPY . .
RUN npm install
RUN npm run build

# Serve aşaması
FROM nginx:alpine
COPY --from=build /app/dist/todo-frontend/browser/ /usr/share/nginx/html
EXPOSE 8080
