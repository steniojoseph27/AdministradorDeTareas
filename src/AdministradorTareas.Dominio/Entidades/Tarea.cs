namespace AdministradorTareas.Dominio.Entidades
{
    public class Tarea
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Usuario { get; set; }        
        public EstadoTarea Estado { get; set; }      
        public PrioridadTarea Prioridad { get; set; }       
        public DateTime FechaCompromiso { get; set; }      
        public string Notas { get; set; }      
        public bool EsEditable => Estado == EstadoTarea.Pendiente;        
        public bool EsEliminable => Estado != EstadoTarea.EnProceso;
    }
}