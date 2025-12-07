using System;
using System.Collections.Generic;
using System.Linq;
using AdministradorTareas.Dominio.Entidades;
using AdministradorTareas.Dominio.Enums;
using AdministradorTareas.Dominio.Repositorios;
using Dapper;

namespace AdministradorTareas.Infraestructura.Repositorios
{
    // Hereda de la clase base para obtener el manejo de la conexión
    public class TareaRepositorio : SqliteBaseRepositorio, ITareaRepositorio
    {
        // SQL Básico para evitar repetición
        private const string SelectQuery = 
            "SELECT Id, Descripcion, Usuario, Estado, Prioridad, FechaCompromiso, Notas FROM Tareas";

        // Implementación de ObtenerTodas
        public IEnumerable<Tarea> ObtenerTodas(string? filtro = null)
        {
            using (var connection = GetConnection())
            {
                var sql = $"{SelectQuery} ORDER BY FechaCompromiso ASC";
                
                return connection.Query<Tarea>(sql).ToList();
            }
        }

        // Implementación de ObtenerPorId
        public Tarea? ObtenerPorId(int id)
        {
            using (var connection = GetConnection())
            {
                var sql = $"{SelectQuery} WHERE Id = @Id";
                return connection.QuerySingleOrDefault<Tarea>(sql, new { Id = id });
            }
        }

        // Implementación de Agregar
        public void Agregar(Tarea tarea)
        {
            using (var connection = GetConnection())
            {
                var sql = @"
                    INSERT INTO Tareas (Descripcion, Usuario, Estado, Prioridad, FechaCompromiso, Notas)
                    VALUES (@Descripcion, @Usuario, @Estado, @Prioridad, @FechaCompromiso, @Notas);";
                
                connection.Execute(sql, tarea);
            }
        }

        // Implementación de Actualizar
        public void Actualizar(Tarea tarea)
        {
            using (var connection = GetConnection())
            {
                var sql = @"
                    UPDATE Tareas SET
                        Descripcion = @Descripcion,
                        Usuario = @Usuario,
                        Estado = @Estado,
                        Prioridad = @Prioridad,
                        FechaCompromiso = @FechaCompromiso,
                        Notas = @Notas
                    WHERE Id = @Id;";

                connection.Execute(sql, tarea);
            }
        }

        // Implementación de Eliminar
        public void Eliminar(int id)
        {
            using (var connection = GetConnection())
            {
                var sql = "DELETE FROM Tareas WHERE Id = @Id";
                connection.Execute(sql, new { Id = id });
            }
        }
    }
}