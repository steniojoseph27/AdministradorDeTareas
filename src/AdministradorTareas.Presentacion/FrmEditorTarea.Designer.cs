using System;
using System.Windows.Forms;
using System.Drawing;

namespace AdministradorTareas.Presentacion
{
    partial class FrmEditorTarea
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblDescripcion = new Label();
            this.txtDescripcion = new TextBox();

            this.lblUsuario = new Label();
            this.txtUsuario = new TextBox();

            this.lblPrioridad = new Label();
            this.cmbPrioridad = new ComboBox();

            this.lblFecha = new Label();
            this.dtFechaCompromiso = new DateTimePicker();

            this.lblNotas = new Label();
            this.txtNotas = new TextBox();

            this.btnGuardar = new Button();
            this.btnCancelar = new Button();

            this.SuspendLayout();

            // lblDescripcion
            this.lblDescripcion.Location = new Point(20, 20);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new Size(80, 13);
            this.lblDescripcion.TabIndex = 0;
            this.lblDescripcion.Text = "Descripción:";

            // txtDescripcion
            this.txtDescripcion.Location = new Point(20, 40);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new Size(340, 20);
            this.txtDescripcion.TabIndex = 1;

            // lblUsuario
            this.lblUsuario.Location = new Point(20, 70);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new Size(40, 13);
            this.lblUsuario.TabIndex = 2;
            this.lblUsuario.Text = "Usuario:";

            // txtUsuario
            this.txtUsuario.Location = new Point(20, 90);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new Size(340, 20);
            this.txtUsuario.TabIndex = 3;

            // lblPrioridad
            this.lblPrioridad.Location = new Point(20, 120);
            this.lblPrioridad.Name = "lblPrioridad";
            this.lblPrioridad.Size = new Size(60, 13);
            this.lblPrioridad.TabIndex = 4;
            this.lblPrioridad.Text = "Prioridad:";

            // cmbPrioridad
            this.cmbPrioridad.Location = new Point(20, 140);
            this.cmbPrioridad.Name = "cmbPrioridad";
            this.cmbPrioridad.Size = new Size(160, 21);
            this.cmbPrioridad.TabIndex = 5;
            this.cmbPrioridad.DropDownStyle = ComboBoxStyle.DropDownList;

            // lblFecha
            this.lblFecha.Location = new Point(200, 120);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new Size(110, 13);
            this.lblFecha.TabIndex = 6;
            this.lblFecha.Text = "Fecha Compromiso:";

            // dtFechaCompromiso
            this.dtFechaCompromiso.Location = new Point(200, 140);
            this.dtFechaCompromiso.Name = "dtFechaCompromiso";
            this.dtFechaCompromiso.Size = new Size(160, 20);
            this.dtFechaCompromiso.TabIndex = 7;
            this.dtFechaCompromiso.Format = DateTimePickerFormat.Short;

            // lblNotas
            this.lblNotas.Location = new Point(20, 170);
            this.lblNotas.Name = "lblNotas";
            this.lblNotas.Size = new Size(32, 13);
            this.lblNotas.TabIndex = 8;
            this.lblNotas.Text = "Notas:";

            // txtNotas
            this.txtNotas.Location = new Point(20, 190);
            this.txtNotas.Name = "txtNotas";
            this.txtNotas.Size = new Size(340, 80);
            this.txtNotas.TabIndex = 9;
            this.txtNotas.Multiline = true;
            this.txtNotas.ScrollBars = ScrollBars.Vertical;

            // btnGuardar
            this.btnGuardar.Location = new Point(200, 290);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new Size(75, 23);
            this.btnGuardar.TabIndex = 10;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new EventHandler(this.btnGuardar_Click);

            // btnCancelar
            this.btnCancelar.DialogResult = DialogResult.Cancel;
            this.btnCancelar.Location = new Point(285, 290);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new Size(75, 23);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new EventHandler(this.btnCancelar_Click);


            // FrmEditorTarea
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(384, 331);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txtNotas);
            this.Controls.Add(this.lblNotas);
            this.Controls.Add(this.dtFechaCompromiso);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.cmbPrioridad);
            this.Controls.Add(this.lblPrioridad);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.lblDescripcion);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmEditorTarea";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Editor de Tarea";

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private Label lblDescripcion;
        public TextBox txtDescripcion;

        private Label lblUsuario;
        public TextBox txtUsuario;

        private Label lblPrioridad;
        public ComboBox cmbPrioridad;

        private Label lblFecha;
        public DateTimePicker dtFechaCompromiso;

        private Label lblNotas;
        public TextBox txtNotas;

        private Button btnGuardar;
        private Button btnCancelar;
    }
}