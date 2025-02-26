using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Sistematic_prueba
{
    public partial class Editar_Form : Form
    {

        private int idUsuario;

        public Editar_Form(int idUsuario)
        {
            InitializeComponent();
            this.idUsuario = idUsuario;
        }

        private void Editar_Form_Load(object sender, EventArgs e)
        {
            LoadComboBoxData();
            LoadUserData();
        }

        private void LoadComboBoxData()
        {
            using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
            {
                connection.Open();

                // Llenar comboBoxPerfil
                string queryPerfil = "SELECT id_perfil, nombre FROM perfiles";
                SqlDataAdapter dataAdapterPerfil = new SqlDataAdapter(queryPerfil, connection);
                DataTable dataTablePerfil = new DataTable();
                dataAdapterPerfil.Fill(dataTablePerfil);
                comboBoxPerfil.DataSource = dataTablePerfil;
                comboBoxPerfil.DisplayMember = "nombre";
                comboBoxPerfil.ValueMember = "id_perfil";

                // Llenar comboBoxCargo
                string queryCargo = "SELECT id_cargo, nombre FROM cargo";
                SqlDataAdapter dataAdapterCargo = new SqlDataAdapter(queryCargo, connection);
                DataTable dataTableCargo = new DataTable();
                dataAdapterCargo.Fill(dataTableCargo);
                comboBoxCargo.DataSource = dataTableCargo;
                comboBoxCargo.DisplayMember = "nombre";
                comboBoxCargo.ValueMember = "id_cargo";
            }
        }

        private void LoadUserData()
        {
            string query = "SELECT nombre, apellido, fecha_de_nacimiento, direccion, id_perfil, id_cargo FROM usuarios WHERE id_usuarios = @idUsuario";

            using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idUsuario", idUsuario);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            textBoxNombre.Text = reader["nombre"].ToString();
                            textBoxApellido.Text = reader["apellido"].ToString();
                            dateTimePickerFechaNacimiento.Value = Convert.ToDateTime(reader["fecha_de_nacimiento"]);
                            textBoxDireccion.Text = reader["direccion"].ToString();
                            comboBoxPerfil.SelectedValue = reader["id_perfil"];
                            comboBoxCargo.SelectedValue = reader["id_cargo"];
                        }
                    }
                }
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            string query = @"
                UPDATE usuarios 
                SET nombre = @nombre, apellido = @apellido, fecha_de_nacimiento = @fecha_de_nacimiento, direccion = @direccion, id_perfil = @id_perfil, id_cargo = @id_cargo 
                WHERE id_usuarios = @idUsuario";

            using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@nombre", textBoxNombre.Text);
                    command.Parameters.AddWithValue("@apellido", textBoxApellido.Text);
                    command.Parameters.AddWithValue("@fecha_de_nacimiento", dateTimePickerFechaNacimiento.Value);
                    command.Parameters.AddWithValue("@direccion", textBoxDireccion.Text);
                    command.Parameters.AddWithValue("@id_perfil", comboBoxPerfil.SelectedValue);
                    command.Parameters.AddWithValue("@id_cargo", comboBoxCargo.SelectedValue);
                    command.Parameters.AddWithValue("@idUsuario", idUsuario);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Usuario actualizado exitosamente.");
            this.Close();
        }
    }
}


