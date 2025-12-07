// Archivo: src/AdministradorTareas.Presentacion/FrmPrincipal.cs

using AdministradorTareas.Dominio.Servicios;
using System.Windows.Forms;

namespace AdministradorTareas.Presentacion
{
    public partial class FrmPrincipal : Form
    {
        private readonly ITareaServicio _tareaServicio;

        // Constructor que acepta la dependencia.
        public FrmPrincipal(ITareaServicio tareaServicio)
        {
            InitializeComponent();
            _tareaServicio = tareaServicio;
            
            // Comprobación mínima de que la comunicación funciona
            this.Text = "Administrador de Tareas (Conexión OK)"; 
            
            // Llamar método de carga de datos aquí.
            CargarTareas();
        }
        
        // Método placeholder para la carga de datos
        private void CargarTareas()
        {
            // Ejemplo de uso:
            // var tareas = _tareaServicio.ObtenerTodasTareas();
            // gridTareas.DataSource = tareas;
        }
    }
}