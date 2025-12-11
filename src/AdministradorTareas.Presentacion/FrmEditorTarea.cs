using AdministradorTareas.Dominio.Entidades;
using AdministradorTareas.Dominio.Enums;
using AdministradorTareas.Dominio.Servicios;
using System;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

namespace AdministradorTareas.Presentacion
{
    public partial class FrmEditorTarea : Form
    {
        private readonly ITareaServicio _tareaServicio;
        private int? _tareaId;
        private Tarea _tareaActual;

        public FrmEditorTarea(ITareaServicio tareaServicio, int? tareaId = null)
        {
            InitializeComponent();
            _tareaServicio = tareaServicio;
            _tareaId = tareaId;

            InicializarControles();
            CargarDatos();
        }

        private void InicializarControles()
        {
            this.Text = _tareaId.HasValue ? "Editar Tarea" : "Crear Nueva Tarea";
            cmbPrioridad.DataSource = Enum.GetValues(typeof(PrioridadTarea)).Cast<PrioridadTarea>().ToList();
        }

        private void CargarDatos()
        {
            if (_tareaId.HasValue)
            {
                _tareaActual = _tareaServicio.ObtenerTareaPorId(_tareaId.Value);

                if (_tareaActual == null)
                {
                    MessageBox.Show("Error: Tarea no encontrada.", "Error de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                if (!_tareaActual.EsEditable)
                {
                    MessageBox.Show("Esta tarea no se puede editar porque no está en estado PENDIENTE.", "Restricción de Negocio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                    return;
                }

                txtDescripcion.Text = _tareaActual.Descripcion;
                txtUsuario.Text = _tareaActual.Usuario;
                cmbPrioridad.SelectedItem = _tareaActual.Prioridad;
                dtFechaCompromiso.Value = _tareaActual.FechaCompromiso;
                txtNotas.Text = _tareaActual.Notas;
            }
            else
            {
                _tareaActual = new Tarea();
                cmbPrioridad.SelectedItem = PrioridadTarea.Media;
                dtFechaCompromiso.Value = DateTime.Today;
            }
        }

        private bool ValidarCampos()
        {
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

            if (dtFechaCompromiso.Value == default)
            {
                MessageBox.Show("La Fecha de Compromiso es obligatoria.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtFechaCompromiso.Focus();
                return false;
            }

            return true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            _tareaActual.Descripcion = txtDescripcion.Text.Trim();
            _tareaActual.Usuario = txtUsuario.Text.Trim();
            _tareaActual.Prioridad = (PrioridadTarea)cmbPrioridad.SelectedItem!;
            _tareaActual.FechaCompromiso = dtFechaCompromiso.Value;
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
                    _tareaServicio.CrearTarea(_tareaActual);
                    MessageBox.Show("Tarea creada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show($"Error de datos: {ex.Message}", "Validación de Negocio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}