using System;
using AdministradorTareas.Dominio.Entidades;
using System.Collections.Generic;

namespace AdministradorTareas.Dominio.Repositorios
{
    // Interfaz que define las operaciones CRUD y de consulta.
    public interface ITareaRepositorio
    {
        IEnumerable<Tarea> ObtenerTodas(string? filtro = null);
        Tarea? ObtenerPorId(int id);
        void Agregar(Tarea tarea);
        void Actualizar(Tarea tarea);
        void Eliminar(int id);
    }
}