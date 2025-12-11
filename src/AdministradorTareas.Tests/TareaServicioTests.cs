using System;
using System.Collections.Generic;
using System.Linq;
using AdministradorTareas.Dominio.Entidades;
using AdministradorTareas.Dominio.Enums;
using AdministradorTareas.Dominio.Repositorios;
using AdministradorTareas.Infraestructura.Servicios;
using Moq;
using Xunit;

namespace AdministradorTareas.Tests
{
    public class TareaServicioTests
    {
        [Fact]
        public void ObtenerTodasTareas_ReturnsAllFromRepository()
        {
            var mockRepo = new Mock<ITareaRepositorio>();
            var sample = new List<Tarea>
            {
                new Tarea { Id = 1, Descripcion = "A", Usuario = "U", Estado = EstadoTarea.Pendiente, Prioridad = PrioridadTarea.Media, FechaCompromiso = DateTime.Today },
                new Tarea { Id = 2, Descripcion = "B", Usuario = "V", Estado = EstadoTarea.EnProceso, Prioridad = PrioridadTarea.Alta, FechaCompromiso = DateTime.Today.AddDays(1) }
            };
            mockRepo.Setup(r => r.ObtenerTodas(It.IsAny<string?>())).Returns(sample);

            var servicio = new TareaServicio(mockRepo.Object);

            var result = servicio.ObtenerTodasTareas().ToList();

            Assert.Equal(2, result.Count);
            Assert.Equal("A", result[0].Descripcion);
            mockRepo.Verify(r => r.ObtenerTodas(It.IsAny<string?>()), Times.Once);
        }

        [Fact]
        public void CrearTarea_CallsRepositorioAgregar()
        {
            var mockRepo = new Mock<ITareaRepositorio>();
            var servicio = new TareaServicio(mockRepo.Object);

            var nueva = new Tarea { Descripcion = "Nueva", Usuario = "X", Estado = EstadoTarea.Pendiente, Prioridad = PrioridadTarea.Baja, FechaCompromiso = DateTime.Today };

            servicio.CrearTarea(nueva);

            mockRepo.Verify(r => r.Agregar(It.Is<Tarea>(t => t.Descripcion == "Nueva")), Times.Once);
        }

        [Fact]
        public void ActualizarTarea_CallsRepositorioActualizar()
        {
            var mockRepo = new Mock<ITareaRepositorio>();
            var servicio = new TareaServicio(mockRepo.Object);

            var tarea = new Tarea { Id = 5, Descripcion = "Edit", Usuario = "Y" };

            servicio.ActualizarTarea(tarea);

            mockRepo.Verify(r => r.Actualizar(It.Is<Tarea>(t => t.Id == 5)), Times.Once);
        }

        [Fact]
        public void EliminarTarea_CallsRepositorioEliminar()
        {
            var mockRepo = new Mock<ITareaRepositorio>();
            var servicio = new TareaServicio(mockRepo.Object);

            servicio.EliminarTarea(42);

            mockRepo.Verify(r => r.Eliminar(42), Times.Once);
        }

        [Fact]
        public void ObtenerTareaPorId_ReturnsRepositoryValue()
        {
            var mockRepo = new Mock<ITareaRepositorio>();
            mockRepo.Setup(r => r.ObtenerPorId(7)).Returns(new Tarea { Id = 7, Descripcion = "X" });

            var servicio = new TareaServicio(mockRepo.Object);

            var t = servicio.ObtenerTareaPorId(7);

            Assert.NotNull(t);
            Assert.Equal(7, t!.Id);
            mockRepo.Verify(r => r.ObtenerPorId(7), Times.Once);
        }
    }
}