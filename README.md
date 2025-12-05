# 📋 Administrador de Tareas

## 📄 Descripción
Aplicación de escritorio desarrollada en C# y WinForms para la administración de tareas sencillas. El proyecto está diseñado con una arquitectura de capas clara, siguiendo patrones de diseño básicos y principios de código limpio, acorde a los estándares de un desarrollador Senior[cite: 15, 18].

## ✨ Características Principales
* **CRUD** (Crear, Ver, Editar, Eliminar) de tareas[cite: 2].
* Visualización tabular con **ordenamiento por Fecha de Compromiso** y **filtros**[cite: 6, 7].
* Flujo de estados: **PENDIENTE > EN PROCESO > TERMINADA**[cite: 7].
* Reglas de edición/eliminación específicas:
    * **Editar:** Solo tareas en estado PENDIENTE[cite: 7].
    * **Eliminar:** Tareas que NO estén en estado EN PROCESO[cite: 8].

## 🛠️ Tecnologías Utilizadas
* **Lenguaje:** C# (.NET Framework / .NET Core)
* **Interfaz:** WinForms
* **Base de Datos (Inicial):** SQLite (Uso de **Dapper** para acceso a datos) 
* **Arquitectura:** En capas (e.g., Presentación, Negocio, Datos) 
* **Patrones:** Se utilizarán patrones como **Repository** y **Unit of Work** para facilitar la migración a Entity Framework[cite: 11, 12].

## ⚙️ Configuración del Entorno y Ejecución
1.  **Requisitos:** Tener instalado Visual Studio (2019 o superior) y el SDK de .NET.
2.  **Clonar Repositorio:** `git clone <URL_del_repositorio>`
3.  **Abrir Solución:** Abrir el archivo `.sln` en Visual Studio.
4.  **Ejecutar:** Compilar y ejecutar la solución (F5). La base de datos SQLite se creará automáticamente en la primera ejecución.

## ✒️ Guía de Estilo de Código (Ejemplo - Detallar más tarde) [cite: 14]
* **Nomenclatura:** Se utiliza **PascalCase** para clases, métodos y propiedades; **camelCase** para variables locales y parámetros.
* **Comentarios:** Brevemente en métodos complejos o lógica de negocio.
* **Uso de `var`:** Se prefiere el uso de tipos explícitos para mayor claridad.