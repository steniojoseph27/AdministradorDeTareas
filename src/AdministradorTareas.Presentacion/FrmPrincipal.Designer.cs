using System.Windows.Forms;

namespace AdministradorTareas.Presentacion
{
    partial class FrmPrincipal
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView gridTareas;
        private System.Windows.Forms.Button btnNuevaTarea;

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
            this.components = new System.ComponentModel.Container();
            this.gridTareas = new System.Windows.Forms.DataGridView();
            this.btnNuevaTarea = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.gridTareas)).BeginInit();
            this.SuspendLayout();

            // 
            // gridTareas
            // 
            this.gridTareas.AllowUserToAddRows = false;
            this.gridTareas.AllowUserToDeleteRows = false;
            this.gridTareas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.gridTareas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridTareas.Location = new System.Drawing.Point(12, 50);
            this.gridTareas.Name = "gridTareas";
            this.gridTareas.ReadOnly = true;
            this.gridTareas.Size = new System.Drawing.Size(760, 399);
            this.gridTareas.TabIndex = 0;
            this.gridTareas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridTareas_CellDoubleClick);

            // 
            // btnNuevaTarea
            // 
            this.btnNuevaTarea.Location = new System.Drawing.Point(12, 12);
            this.btnNuevaTarea.Name = "btnNuevaTarea";
            this.btnNuevaTarea.Size = new System.Drawing.Size(100, 32);
            this.btnNuevaTarea.TabIndex = 1;
            this.btnNuevaTarea.Text = "Nueva Tarea";
            this.btnNuevaTarea.UseVisualStyleBackColor = true;
            this.btnNuevaTarea.Click += new System.EventHandler(this.btnNuevaTarea_Click);

            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.btnNuevaTarea);
            this.Controls.Add(this.gridTareas);
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            ((System.ComponentModel.ISupportInitialize)(this.gridTareas)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion
    }
}
