using System;
using System.Data;
using Microsoft.Data.Sqlite;
using System.IO;
using Dapper;

namespace AdministradorTareas.Infraestructura.Repositorios
{
    public abstract class SqliteBaseRepositorio
    {
        private readonly string _connectionString;
        private readonly string _dbFilePath = "TareasDB.sqlite";

        // Constructor protegido para inicializar la conexión
        protected SqliteBaseRepositorio()
        {
            _connectionString = $"Data Source={_dbFilePath};";
            
            InicializarBaseDatos();
        }

        // Método para obtener una conexión abierta
        protected IDbConnection GetConnection()
        {
            var connection = new SqliteConnection(_connectionString);
            connection.Open();
            return connection;
        }

        private void InicializarBaseDatos()
        {
            var createSql = @"
                CREATE TABLE IF NOT EXISTS Tareas (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Descripcion TEXT NOT NULL,
                    Usuario TEXT NOT NULL,
                    Estado INTEGER NOT NULL,
                    Prioridad INTEGER NOT NULL,
                    FechaCompromiso TEXT NOT NULL,
                    Notas TEXT
                );";

            if (!File.Exists(_dbFilePath))
            {
                using (var connection = new SqliteConnection(_connectionString))
                {
                    connection.Open();
                    connection.Execute(createSql);

                    // Insertar datos de ejemplo
                    var insertSql = @"
                        INSERT INTO Tareas (Descripcion, Usuario, Estado, Prioridad, FechaCompromiso, Notas)
                        VALUES (@Descripcion, @Usuario, @Estado, @Prioridad, @FechaCompromiso, @Notas);";

                    var seeds = new[]
                    {
                        new {
                            Descripcion = "Revisar reportes mensuales",
                            Usuario = "Ana",
                            Estado = 1, // Pendiente
                            Prioridad = 2, // Media
                            FechaCompromiso = DateTime.Today.AddDays(2),
                            Notas = "Incluir resumen de ventas"
                        },
                        new {
                            Descripcion = "Actualizar servidor de pruebas",
                            Usuario = "Carlos",
                            Estado = 2, // EnProceso
                            Prioridad = 3, // Alta
                            FechaCompromiso = DateTime.Today.AddDays(1),
                            Notas = "Backup antes de actualizar"
                        },
                        new {
                            Descripcion = "Planificar reunión de equipo",
                            Usuario = "María",
                            Estado = 1, // Pendiente
                            Prioridad = 1, // Baja
                            FechaCompromiso = DateTime.Today.AddDays(7),
                            Notas = "Enviar invitaciones"
                        }
                    };

                    connection.Execute(insertSql, seeds);
                }
            }
            else
            {
                // Si el archivo existe, asegurar que la tabla exista y sembrar si está vacía
                using (var connection = GetConnection())
                {
                    connection.Execute(createSql);
                    var count = connection.ExecuteScalar<int>("SELECT COUNT(1) FROM Tareas;");
                    if (count == 0)
                    {
                        var insertSql = @"
                            INSERT INTO Tareas (Descripcion, Usuario, Estado, Prioridad, FechaCompromiso, Notas)
                            VALUES (@Descripcion, @Usuario, @Estado, @Prioridad, @FechaCompromiso, @Notas);";

                        var seeds = new[]
                        {
                            new {
                                Descripcion = "Revisar reportes mensuales",
                                Usuario = "Ana",
                                Estado = 1,
                                Prioridad = 2,
                                FechaCompromiso = DateTime.Today.AddDays(2),
                                Notas = "Incluir resumen de ventas"
                            },
                            new {
                                Descripcion = "Actualizar servidor de pruebas",
                                Usuario = "Carlos",
                                Estado = 2,
                                Prioridad = 3,
                                FechaCompromiso = DateTime.Today.AddDays(1),
                                Notas = "Backup antes de actualizar"
                            },
                            new {
                                Descripcion = "Planificar reunión de equipo",
                                Usuario = "María",
                                Estado = 1,
                                Prioridad = 1,
                                FechaCompromiso = DateTime.Today.AddDays(7),
                                Notas = "Enviar invitaciones"
                            }
                        };

                        connection.Execute(insertSql, seeds);
                    }
                }
            }
        }
    }
}