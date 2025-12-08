using System;
using AdministradorTareas.Dominio.Enums;

namespace AdministradorTareas.Dominio.Entidades
{
    public class Tarea
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public string Usuario { get; set; } = string.Empty;        
        public EstadoTarea Estado { get; set; }      
        public PrioridadTarea Prioridad { get; set; }       
        public DateTime FechaCompromiso { get; set; }      
        public string Notas { get; set; } = string.Empty;      
        public bool EsEditable => Estado == EstadoTarea.Pendiente;        
        public bool EsEliminable => Estado != EstadoTarea.EnProceso;
    }
}