# ProductAPI Double V Partners

## Descripción del Proyecto

ProductAPI es una API RESTful desarrollada en .NET 8.0 como prueba técnica para Double V Partners que permite buscar productos en una tienda en línea y obtener información básica sobre ellos, todo a traves de un API (se aconseja usar POSTMAN para ello). Además, ofrece funcionalidades para guardar productos como "productos deseados" y consultarlos posteriormente.

## Requerimientos

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (o [LocalDB](https://docs.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-express-localdb))
- [Postman](https://www.postman.com/) (para probar los endpoints)

## Iniciar el Proyecto

### 1. Clonar el Repositorio

Primero, clona el repositorio a tu máquina local:

```bash
git clone https://github.com/estebanm1892/productAPI
cd productAPI
```

### 2. Configurar la conexión a la Base de Datos

Modificar el archivo appsettings.json para la conexión

```bash
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    },
    "ConnectionStrings": {
      "DefaultConnection": "Server=(localdb)\\mylocaldb;Database=doublev_db;Trusted_Connection=True;"
    }
  },
  "AllowedHosts": "*"
}
```

### 3. Crear la Base de Datos y ejecutar las migraciones
```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### 4. Iniciar el proyecto
#### 1. Construir y ejecutar el proyecto
```bash
dotnet build
dotnet run
```
Esto iniciará la aplicación en http://localhost:5170 (puede variar según los puertos definidos en Properties/launchSettings.json).

#### 2. Probar los endpoints
Utiliza herramientas como Postman para probar los siguientes endpoints:

```bash

GET /api/categories - Consultar listado de categorías de productos.
GET /api/products - Consultar listado de productos.
GET /api/products/{id} - Consultar detalle de un producto.
POST /api/wishlist - Agregar un producto como "producto deseado".
(Con Postman en el body con RAW se puede agregar un producto de la siguiente forma)
{
    "productId": 2,
    "userId": 1
}
DELETE /api/wishlist/{id} - Eliminar un producto deseado.

GET /api/wishlist/{userId} - Consultar listado de productos deseados de un usuario.
```
# Estructura del proyecto

- Controllers: Contiene los controladores de API.
- Models: Contiene las entidades del modelo de datos.
- Data: Contiene el contexto de la base de datos y las configuraciones iniciales.
- Migrations: Contiene las migraciones de la base de datos.

