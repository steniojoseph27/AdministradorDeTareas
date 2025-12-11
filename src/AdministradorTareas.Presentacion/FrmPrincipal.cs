using AdministradorTareas.Dominio.Servicios;
using System;
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
           
            this.Text = "Administrador de Tareas (Conexión OK)";
            
            CargarTareas();
            ConfigurarGrid();
        }
        
        // Método para cargar las tareas
        private void CargarTareas()
        {
            try
            {
                var tareas = _tareaServicio.ObtenerTodasTareas();
                gridTareas.DataSource = new BindingSource(tareas, null);
                ConfigurarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar tareas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarGrid()
        {
            if (gridTareas.Columns.Count == 0) return;

            if (gridTareas.Columns.Contains("EsEditable"))
                gridTareas.Columns["EsEditable"].Visible = false;
            if (gridTareas.Columns.Contains("EsEliminable"))
                gridTareas.Columns["EsEliminable"].Visible = false;

            gridTareas.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void btnNuevaTarea_Click(object sender, EventArgs e)
        {
            using var frmEditor = new FrmEditorTarea(_tareaServicio);
            if (frmEditor.ShowDialog() == DialogResult.OK)
            {
                CargarTareas();
            }
        }

        private void gridTareas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var tareaId = (int)gridTareas.Rows[e.RowIndex].Cells["Id"].Value;

            using var frmEditor = new FrmEditorTarea(_tareaServicio, tareaId);
            if (frmEditor.ShowDialog() == DialogResult.OK)
            {
                CargarTareas();
            }
        }
    }
}