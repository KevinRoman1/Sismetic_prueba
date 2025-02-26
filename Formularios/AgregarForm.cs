using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Sistematic_prueba
{
    public partial class AgregarForm : Form
    {
        public event EventHandler UsuarioAgregado;

        public AgregarForm()
        {
            InitializeComponent();
        }

        private void AgregarForm_Load(object sender, EventArgs e)
        {
            LoadComboBoxData();
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string query = @"
            INSERT INTO usuarios (nombre, apellido, fecha_de_nacimiento, direccion, id_perfil, id_cargo, estado)
            VALUES (@nombre, @apellido, @fecha_de_nacimiento, @direccion, @id_perfil, @id_cargo, 1)";

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

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Usuario agregado exitosamente.");
            UsuarioAgregado?.Invoke(this, EventArgs.Empty);
            this.Close();
        }
    }
}






