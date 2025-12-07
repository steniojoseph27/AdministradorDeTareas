// Fragmento de src/AdministradorTareas.Presentacion/FrmEditorTarea.cs

using AdministradorTareas.Dominio.Entidades;
using AdministradorTareas.Dominio.Enums;
using AdministradorTareas.Dominio.Servicios;
using System;
using System.Linq; 
using System.Windows.Forms; 
using System.Collections.Generic; // Para el manejo de Enums

namespace AdministradorTareas.Presentacion
{
    // Asumimos que usa una clase base de DevExpress para formularios
    public partial class FrmEditorTarea : DevExpress.XtraEditors.XtraForm
    {
        private readonly ITareaServicio _tareaServicio;
        private int? _tareaId;
        private Tarea _tareaActual;

        // Constructor con Inyección de Dependencia y parámetro opcional
        public FrmEditorTarea(ITareaServicio tareaServicio, int? tareaId = null)
        {
            InitializeComponent();
            _tareaServicio = tareaServicio;
            _tareaId = tareaId;
            
            InicializarControles();
            CargarDatos();
        }
        
        // ...
        // Fragmento de src/AdministradorTareas.Presentacion/FrmEditorTarea.cs (Continuación)

        private void InicializarControles()
        {
            this.Text = _tareaId.HasValue ? "Editar Tarea" : "Crear Nueva Tarea";
            
            // Configuración del ComboBox de Prioridad (Asumiendo DevExpress cmbPrioridad)
            cmbPrioridad.Properties.Items.AddRange(
                Enum.GetValues(typeof(PrioridadTarea)).Cast<PrioridadTarea>().ToList()
            );
        }

        private void CargarDatos()
        {
            if (_tareaId.HasValue)
            {
                // MODO EDICIÓN
                _tareaActual = _tareaServicio.ObtenerTareaPorId(_tareaId.Value);

                if (_tareaActual == null)
                {
                    MessageBox.Show("Error: Tarea no encontrada.", "Error de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                // VALIDACIÓN DE REGLA DE NEGOCIO: SOLO PENDIENTES
                if (!_tareaActual.EsEditable)
                {
                    MessageBox.Show("Esta tarea no se puede editar porque no está en estado PENDIENTE.", "Restricción de Negocio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close(); // Cerrar el formulario si no es editable
                    return;
                }
                
                // Cargar datos (Asumiendo nombres de controles DX: txtDescripcion, dtFechaCompromiso, etc.)
                txtDescripcion.Text = _tareaActual.Descripcion;
                txtUsuario.Text = _tareaActual.Usuario;
                cmbPrioridad.EditValue = _tareaActual.Prioridad;
                dtFechaCompromiso.EditValue = _tareaActual.FechaCompromiso;
                txtNotas.Text = _tareaActual.Notas;
            }
            else
            {
                // MODO CREACIÓN
                _tareaActual = new Tarea();
                cmbPrioridad.EditValue = PrioridadTarea.Media; // Valor por defecto
                dtFechaCompromiso.EditValue = DateTime.Today;
            }
        }

        // Lógica: Validación de Campos Obligatorios
        private bool ValidarCampos()
        {
            // Usaremos el componente DX ErrorProvider si está disponible, si no, MessageBox
            
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("La Descripción es obligatoria.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescripcion.Focus();
                return false;
            }
            
            if (string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                MessageBox.Show("El Usuario asignado es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsuario.Focus();
                return false;
            }
            
            if (dtFechaCompromiso.EditValue == null)
            {
                MessageBox.Show("La Fecha de Compromiso es obligatoria.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtFechaCompromiso.Focus();
                return false;
            }

            return true;
        }

        // Lógica: Botón Guardar
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            // Mapear datos de los controles a la entidad
            _tareaActual.Descripcion = txtDescripcion.Text.Trim();
            _tareaActual.Usuario = txtUsuario.Text.Trim();
            _tareaActual.Prioridad = (PrioridadTarea)cmbPrioridad.EditValue;
            _tareaActual.FechaCompromiso = (DateTime)dtFechaCompromiso.EditValue;
            _tareaActual.Notas = txtNotas.Text;

            try
            {
                if (_tareaId.HasValue)
                {
                    _tareaServicio.ActualizarTarea(_tareaActual);
                    MessageBox.Show("Tarea actualizada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // El servicio se encarga de asignar el estado inicial PENDIENTE
                    _tareaServicio.CrearTarea(_tareaActual); 
                    MessageBox.Show("Tarea creada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK; // Indica a FrmPrincipal que se actualice
                this.Close();
            }
            // Manejo de Excepciones: Captura cualquier error de validación del servicio
            catch (ArgumentException ex) 
            {
                MessageBox.Show($"Error de datos: {ex.Message}", "Validación de Negocio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}