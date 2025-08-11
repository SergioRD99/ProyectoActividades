# ProyectoActividades

API REST para el control y gestión de tareas, desarrollada con .NET 9. Este proyecto permite realizar operaciones CRUD (Crear, Leer, Actualizar, Eliminar) sobre tareas, facilitando la organización del día a día.

## 🚀 Instrucciones para ejecutar el proyecto

### Requisitos previos
- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [Visual Studio 2022](https://visualstudio.microsoft.com/es/vs/) o [Visual Studio Code](https://code.visualstudio.com/)
- [SQL Server](https://www.microsoft.com/es-es/sql-server/sql-server-downloads) (LocalDB incluido con Visual Studio)

### Pasos para la configuración

1. **Clonar el repositorio**
   ```bash
   git clone https://github.com/tu-usuario/ProyectoActividades.git
   cd ProyectoActividades
   ```

2. **Configurar la base de datos**
   - Abrir el proyecto en Visual Studio o VS Code
   - Actualizar la cadena de conexión en `appsettings.json`
   - Ejecutar las migraciones:
     ```bash
     dotnet ef database update
     ```

3. **Ejecutar la aplicación**
   ```bash
   dotnet run
   ```
   La aplicación estará disponible en: `https://localhost:5001` o `http://localhost:5000`

## 📦 Dependencias necesarias

### Principales paquetes NuGet
- `Microsoft.EntityFrameworkCore` - ORM para acceso a datos
- `Microsoft.EntityFrameworkCore.SqlServer` - Proveedor de SQL Server para EF Core
- `Microsoft.EntityFrameworkCore.Tools` - Herramientas para migraciones
- `Swashbuckle.AspNetCore` - Documentación de la API (Swagger/OpenAPI)
- `AutoMapper` - Mapeo de objetos
- `Microsoft.AspNetCore.Identity.EntityFrameworkCore` - Autenticación y autorización

### Dependencias de desarrollo
- `Microsoft.NET.Test.Sdk` - Para pruebas unitarias
- `xunit` - Framework de pruebas
- `Moq` - Para mock en pruebas unitarias

## 🛠️ Cómo funciona el sistema

### Estructura del proyecto
- `Controllers/` - Controladores de la API
- `Models/` - Modelos de datos
- `Data/` - Configuración de la base de datos y migraciones
- `Services/` - Lógica de negocio
- `DTOs/` - Objetos de transferencia de datos
- `Mappings/` - Configuraciones de AutoMapper

### Características principales
- **Gestión de tareas**: Crear, leer, actualizar y eliminar tareas
- **Categorización**: Organizar tareas por categorías
- **Priorización**: Establecer prioridades a las tareas
- **Filtrado y búsqueda**: Filtrar tareas por estado, prioridad o categoría
- **Autenticación y autorización**: Seguridad basada en roles

### Endpoints principales
- `GET /api/tareas` - Obtener todas las tareas
- `GET /api/tareas/{id}` - Obtener una tarea por ID
- `POST /api/tareas` - Crear una nueva tarea
- `PUT /api/tareas/{id}` - Actualizar una tarea existente
- `DELETE /api/tareas/{id}` - Eliminar una tarea

## 📝 Documentación de la API

Puedes acceder a la documentación interactiva de la API (Swagger) en:
```
https://localhost:5001/swagger
```

## 🤝 Contribución

Las contribuciones son bienvenidas. Por favor, lee las [pautas de contribución](CONTRIBUTING.md) para más detalles.

## 📄 Licencia

Este proyecto está bajo la Licencia MIT - ver el archivo [LICENSE](LICENSE) para más detalles.
