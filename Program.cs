using Microsoft.Data.SqlClient;

namespace Sistematic_prueba
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Registro_Usuarios());
        }

    }

}