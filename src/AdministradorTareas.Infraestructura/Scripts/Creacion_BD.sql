-- Script para crear la tabla Tareas
CREATE TABLE IF NOT EXISTS Tareas (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Descripcion TEXT NOT NULL,
    Usuario TEXT NOT NULL,
    Estado INTEGER NOT NULL,
    Prioridad INTEGER NOT NULL,
    FechaCompromiso TEXT NOT NULL,
    Notas TEXT
);