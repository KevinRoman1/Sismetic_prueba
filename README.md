
# Registro Usuarios Sistematic

Este proyecto permite la visualizacion,ingreso y modificacion de usuarios de una base de datos.

 Se proporciona el script SQL para la creación de la base de datos solicitada, así como instrucciones para configurar la conexión en el código, dentro del script de la generacion de la Base de datos esta le genera un Usuario="admin" y contraseña="admin" para la manipulacion de la misma.

## 🚀 Requisitos Previos

Asegúrate de tener instalados los siguientes requisitos antes de continuar:

- SQL Server [2022]
- .NET [9 o superior]
- SQL Server Management Studio (opcional)

## 🛠️ Instalación

### 1️⃣ **Crear la Base de Datos**
Ejecuta el siguiente script en SQL Server para crear la base de datos y las tablas necesarias:

1. Abre **SQL Server Management Studio (SSMS)**.
2. Conéctate a tu instancia de SQL Server.
3. Ejecuta el script `Query BD_ROMAN` incluido en este repositorio.

### 2️⃣**Modificar la Conexion de la Base de Datos**
El archivo DatabaseConfig.cs contiene la configuración de la conexión a la base de datos.
Es necesario modificar el connection string para que apunte a tu servidor SQL.

📍 Ubicación del archivo:

/Sismetic_prueba/Config/DatabaseConfig.cs

📍 Ejemplo del código en DatabaseConfig.cs:

public static string ConnectionString { get; } = @"Server=TU_SERVIDOR;Database=NombreBaseDatos;User Id=TU_USUARIO;Password=TU_CONTRASEÑA;TrustServerCertificate=True";

**Pasos para modificarlo:**

1. Reemplaza TU_SERVIDOR con el nombre de tu servidor SQL.
Si es local, usa localhost o 127.0.0.1.
Si es una instancia de SQL Server Express, usa localhost\SQLEXPRESS.

2. Cambia NombreBaseDatos por el nombre de la base de datos proporcionada en el script SQL(BD_ROMAN).

3. Configura el usuario y la contraseña si usas autenticación SQL Server.

4. (PASO OPCIONAL)Si usas autenticación de Windows, cambia la conexión a: public static string ConnectionString { get; } = @"Server=TU_SERVIDOR;Database=NombreBaseDatos;Integrated Security=True;TrustServerCertificate=True;";

### 3️⃣**Ejecuta el proyecto**
Ejecutar el proyecto mediante Visual Studio o mediante la terminal con: dotnet run







