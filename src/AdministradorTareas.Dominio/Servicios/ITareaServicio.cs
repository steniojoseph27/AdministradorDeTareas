using System.Collections.Generic;
using AdministradorTareas.Dominio.Entidades;

namespace AdministradorTareas.Dominio.Servicios
{
    public interface ITareaServicio
    {
        IEnumerable<Tarea> ObtenerTodasTareas(string? filtro = null);
        Tarea? ObtenerTareaPorId(int id);
        void CrearTarea(Tarea tarea);
        void ActualizarTarea(Tarea tarea);
        void EliminarTarea(int id);
    }
}