using System.Collections.Generic;
using AdministradorTareas.Dominio.Entidades;
using AdministradorTareas.Dominio.Repositorios;
using AdministradorTareas.Dominio.Servicios;

namespace AdministradorTareas.Infraestructura.Servicios
{
    public class TareaServicio : ITareaServicio
    {
        private readonly ITareaRepositorio _repositorio;

        public TareaServicio(ITareaRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public IEnumerable<Tarea> ObtenerTodasTareas(string? filtro = null)
        {
            return _repositorio.ObtenerTodas(filtro);
        }

        public Tarea? ObtenerTareaPorId(int id)
        {
            return _repositorio.ObtenerPorId(id);
        }

        public void CrearTarea(Tarea tarea)
        {
            _repositorio.Agregar(tarea);
        }

        public void ActualizarTarea(Tarea tarea)
        {
            _repositorio.Actualizar(tarea);
        }

        public void EliminarTarea(int id)
        {
            _repositorio.Eliminar(id);
        }
    }
}