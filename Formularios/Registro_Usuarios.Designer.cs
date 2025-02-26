namespace Sistematic_prueba
{
    partial class Registro_Usuarios
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnInactivar;
        private System.Windows.Forms.Button btnNuevo;

        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            btnEditar = new Button();
            btnInactivar = new Button();
            btnNuevo = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = true;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.BackgroundColor = SystemColors.InactiveCaption;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Top;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Margin = new Padding(3, 4, 3, 4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(1003, 287);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(168, 295);
            btnEditar.Margin = new Padding(3, 4, 3, 4);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(150, 38);
            btnEditar.TabIndex = 1;
            btnEditar.Text = "Editar Registro";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            btnEditar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            // 
            // btnInactivar
            // 
            btnInactivar.Location = new Point(324, 295);
            btnInactivar.Margin = new Padding(3, 4, 3, 4);
            btnInactivar.Name = "btnInactivar";
            btnInactivar.Size = new Size(150, 38);
            btnInactivar.TabIndex = 2;
            btnInactivar.Text = "Inactivar el Registro";
            btnInactivar.UseVisualStyleBackColor = true;
            btnInactivar.Click += btnInactivar_Click;
            btnInactivar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(12, 295);
            btnNuevo.Margin = new Padding(3, 4, 3, 4);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(150, 38);
            btnNuevo.TabIndex = 3;
            btnNuevo.Text = "Nuevo Registro";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            btnNuevo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1003, 342);
            Controls.Add(btnNuevo);
            Controls.Add(btnInactivar);
            Controls.Add(btnEditar);
            Controls.Add(dataGridView1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Registro de Usuarios";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }
    }
}








