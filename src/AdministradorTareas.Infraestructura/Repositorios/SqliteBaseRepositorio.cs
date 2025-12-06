using System.Data;
using System.Data.SQLite;
using System.IO;
using Dapper;

namespace AdministradorTareas.Infraestructura.Repositorios
{
    public abstract class SqliteBaseRepositorio
    {
        private readonly string _connectionString;
        private readonly string _dbFilePath = "TareasDB.sqlite";
        protected SqliteBaseRepositorio()
        {
            _connectionString = $"Data Source={_dbFilePath};Version=3;";
            
            InicializarBaseDatos();
        }

        // Método para obtener una conexión abierta
        protected IDbConnection GetConnection()
        {
            var connection = new SQLiteConnection(_connectionString);
            connection.Open();
            return connection;
        }

        private void InicializarBaseDatos()
        {
            if (!File.Exists(_dbFilePath))
            {
                SQLiteConnection.CreateFile(_dbFilePath);
                
                // Usamos Dapper para ejecutar el script de creación de tabla
                using (var connection = GetConnection())
                {
                    // Script SQL para crear la tabla Tareas
                    var sql = @"
                        CREATE TABLE Tareas (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Descripcion TEXT NOT NULL,
                            Usuario TEXT NOT NULL,
                            Estado INTEGER NOT NULL,
                            Prioridad INTEGER NOT NULL,
                            FechaCompromiso TEXT NOT NULL,
                            Notas TEXT
                        );";
                    connection.Execute(sql);
                }
            }
        }
    }
}