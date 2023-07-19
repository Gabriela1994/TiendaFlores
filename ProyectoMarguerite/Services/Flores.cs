using ProyectoMarguerite.Models;
using System.Data;
using Microsoft.Data.SqlClient;
using ProyectoMarguerite.Models.ViewModels;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using System.Drawing;

namespace ProyectoMarguerite.Services
{
    public class Flores
    {


        public void CargaUnaFlor(FloresViewModel flores)
        {
            SqlConnection Bd = DbUtils.RecuperarConnection();

            try
            {
                string query = @"INSERT INTO Flores
                                (nombre, descripcion, precio, Id_especie, Id_color) 
                                VALUES(@Nombre,@Descripcion,@Precio, @IdEspecie, @IdColor)";

                SqlParameter nombre = new SqlParameter("Nombre", flores.Nombre);
                SqlParameter descripcion = new SqlParameter("Descripcion", flores.Descripcion);
                SqlParameter precio = new SqlParameter("Precio", flores.Precio);
                SqlParameter idEspecie = new SqlParameter("IdEspecie", flores.Id_especie);
                SqlParameter idColor = new SqlParameter("IdColor", flores.Id_color);

                SqlCommand command = new SqlCommand(query, Bd);
                command.Parameters.Add(nombre);
                command.Parameters.Add(descripcion);
                command.Parameters.Add(precio);
                command.Parameters.Add(idEspecie);
                command.Parameters.Add(idColor);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error {ex}");
            }
            finally
            {
                Bd.Close();
            }

        }
    }
}
