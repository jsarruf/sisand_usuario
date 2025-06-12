# Dockerfile for fullstack usuario_sis (.NET + Angular)

# Build frontend
FROM node:20 AS build-frontend
WORKDIR /app/frontend
COPY frontend/ ./
RUN npm install && npm run build

# Build backend
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-backend
WORKDIR /app
COPY backend/ ./backend
COPY --from=build-frontend /app/frontend/dist/ ./backend/wwwroot
WORKDIR /app/backend
RUN dotnet publish -c Release -o /app/publish

# Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build-backend /app/publish .
EXPOSE 80
ENTRYPOINT ["dotnet", "usuario_sis.dll"]
