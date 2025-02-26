using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Sistematic_prueba
{
    public partial class Registro_Usuarios : Form
    {
        public Registro_Usuarios()
        {
            InitializeComponent();
            ConnectToDatabase();
        }

        private void ConnectToDatabase()
        {
            
            try
            {
                using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    connection.Open();
                    LoadData(connection);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al conectar a SQL Server: " + e.Message);
            }
        }

        private void UpdateEstado(int idUsuario, bool nuevoEstado)
        {
           
            string query = "UPDATE usuarios SET estado = @nuevoEstado WHERE id_usuarios = @idUsuario";

            using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@nuevoEstado", nuevoEstado);
                    command.Parameters.AddWithValue("@idUsuario", idUsuario);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        private void LoadData(SqlConnection connection)
        {
            string query = @"
            SELECT 
                u.id_usuarios, 
                u.nombre, 
                u.apellido, 
                u.fecha_de_nacimiento, 
                u.direccion, 
                u.estado, 
                p.nombre AS perfil_nombre, 
                c.nombre AS cargo_nombre 
            FROM 
                usuarios u
            JOIN 
                perfiles p ON u.id_perfil = p.id_perfil
            JOIN 
                cargo c ON u.id_cargo = c.id_cargo";

            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            if (!dataTable.Columns.Contains("estado usuario"))
            {
                dataTable.Columns.Add("estado usuario", typeof(string));
            }
            foreach (DataRow row in dataTable.Rows)
            {
                row["estado usuario"] = row["estado"] != DBNull.Value && (bool)row["estado"] ? "ACTIVO" : "INACTIVO";
            }

            dataGridView1.DataSource = dataTable;

            if (dataGridView1.Columns["estado"] != null)
            {
                dataGridView1.Columns["estado"].Visible = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedRowIndex = dataGridView1.SelectedRows[0].Index;
                int idUsuario = (int)dataGridView1.Rows[selectedRowIndex].Cells["id_usuarios"].Value;

                Editar_Form editarForm = new Editar_Form(idUsuario);
                editarForm.ShowDialog();

                // Actualizar los datos después de cerrar el formulario de edición
                ConnectToDatabase();
            }
            else
            {
                MessageBox.Show("Seleccione un registro para editar.");
            }
        }

        private void btnInactivar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedRowIndex = dataGridView1.SelectedRows[0].Index;
                int idUsuario = (int)dataGridView1.Rows[selectedRowIndex].Cells["id_usuarios"].Value;
                bool estadoActual = (bool)dataGridView1.Rows[selectedRowIndex].Cells["estado"].Value;
                bool nuevoEstado = !estadoActual;

                // Actualizar el estado en la base de datos
                UpdateEstado(idUsuario, nuevoEstado);

                // Actualizar el estado en el DataGridView
                dataGridView1.Rows[selectedRowIndex].Cells["estado"].Value = nuevoEstado;
                dataGridView1.Rows[selectedRowIndex].Cells["estado usuario"].Value = nuevoEstado ? "ACTIVO" : "INACTIVO";
            }
            else
            {
                MessageBox.Show("Seleccione un registro para inactivar.");
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            AgregarForm agregarForm = new AgregarForm();
            agregarForm.UsuarioAgregado += (s, args) => ConnectToDatabase();
            agregarForm.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}




