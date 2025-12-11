# 📋 Administrador de Tareas

## 📄 Descripción
Aplicación de escritorio desarrollada en C# y WinForms para la administración de tareas sencillas. El proyecto está diseñado con una arquitectura de capas clara, siguiendo patrones de diseño básicos y principios de código limpio, acorde a los estándares de un desarrollador Senior.

📦 Repositorio
URL: https://github.com/steniojoseph27/AdministradorDeTareas

## ✨ Características Principales
* **CRUD** (Crear, Ver, Editar, Eliminar) de tareas.
* Visualización tabular con **ordenamiento por Fecha de Compromiso** y **filtros**.
* Flujo de estados: **PENDIENTE > EN PROCESO > TERMINADA**.
* Reglas de edición/eliminación específicas:
    * **Editar:** Solo tareas en estado PENDIENTE.
    * **Eliminar:** Tareas que NO estén en estado EN PROCESO.

## 🛠️ Tecnologías Utilizadas
* **Lenguaje:** C# (.NET Framework / .NET Core)
* **Interfaz:** WinForms
* **Base de Datos (Inicial):** SQLite (Uso de **Dapper** para acceso a datos) 
* **Arquitectura:** En capas (e.g., Presentación, Negocio, Datos) 
* **Patrones:** Se utilizarán patrones como **Repository** y **Unit of Work** para facilitar la migración a Entity Framework.
* **Tests:** xUnit + Moq (opcional)

## ⚙️ Configuración del Entorno y Ejecución
1.  **Requisitos:** Tener instalado Visual Studio (2019 o superior) y el SDK de .NET.
2.  **Clonar Repositorio:** `git clone https://github.com/steniojoseph27/AdministradorDeTareas`
3.  **Abrir Solución:** Abrir el archivo `.sln` en Visual Studio o VS Code con extensión C# (opcional).
4.  **Ejecutar:** Ejecutar el proyecto de presentación:
dotnet run --project src/AdministradorTareas.Presentacion
Alternativa: abrir AdministradorDeTareas.sln en Visual Studio y ejecutar (F5). La base de datos SQLite se creará automáticamente en la primera ejecución.

4.a **Notas:**
En la primera ejecución se crea TareasDB.sqlite en la carpeta del proyecto de infraestructura.
Para forzar recreación y ver los datos de ejemplo, borra TareasDB.sqlite y ejecuta de nuevo.

## ✅ Ejecutar pruebas
Si existe el proyecto de pruebas (xUnit), ejecuta todas las pruebas:

dotnet test
o sólo el proyecto de pruebas:

dotnet test src/AdministradorTareas.Tests
🧪 Sobre pruebas
Las pruebas unitarias usan Moq para simular ITareaRepositorio y validar TareaServicio.
Para pruebas de integración con SQLite se recomienda inyectar la conexión o usar Data Source=:memory: con la conexión abierta durante la prueba para evitar efectos secundarios en disco.

## ✒️ Guía de Estilo de Código (Ejemplo - Detallar más tarde) 
* **Nomenclatura:** Se utiliza **PascalCase** para clases, métodos y propiedades; **camelCase** para variables locales y parámetros.
* **Comentarios:** Brevemente en métodos complejos o lógica de negocio.
* **Uso de `var`:** Se prefiere el uso de tipos explícitos para mayor claridad.