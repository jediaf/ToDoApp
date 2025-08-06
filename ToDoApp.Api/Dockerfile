FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ToDoApp.Api/ToDoApp.Api.csproj ToDoApp.Api/
COPY ToDoApp.Core/ToDoApp.Core.csproj ToDoApp.Core/
COPY ToDoApp.Infrastructure/ToDoApp.Infrastructure.csproj ToDoApp.Infrastructure/

RUN dotnet restore "ToDoApp.Api/ToDoApp.Api.csproj"

COPY . .

WORKDIR /src/ToDoApp.Api
RUN dotnet publish "ToDoApp.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app

RUN mkdir -p /data

# Doğru yerden kopyala:
COPY --from=build /app/publish .



ENTRYPOINT ["dotnet", "ToDoApp.Api.dll"]
