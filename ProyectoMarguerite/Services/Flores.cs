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
                string query = @"INSERT INTO Flores (descripcion, precio, Id_especie, Id_color) 
                                VALUES(@Descripcion,@Precio, @IdEspecie, @IdColor)";

                SqlParameter descripcion = new SqlParameter("Descripcion", flores.Descripcion);
                SqlParameter precio = new SqlParameter("Precio", flores.Precio);
                SqlParameter idEspecie = new SqlParameter("IdEspecie", flores.Id_especie);
                SqlParameter idColor = new SqlParameter("IdColor", flores.Id_color);

                SqlCommand command = new SqlCommand(query, Bd);
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

        public List<Models.Flores> ListaFlores2()
        {
            SqlConnection Bd = DbUtils.RecuperarConnection();
            List<Models.Flores> listaFlores = new List<Models.Flores>();
            try
            {
                string query = @"select f.Id, p.nombre as Nombre_flor, c.nombre as Color, f.precio, f.descripcion from flores as f
                                    inner join Especie as p
                                    on f.Id_especie = p.Id
                                    inner join Color as c
                                    on f.Id_color = c.Id";

                SqlCommand command = new SqlCommand(query, Bd);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Models.Flores flores = new Models.Flores();
                    flores.Id = (int)reader["Id"];
                    flores.Especie = (string)(reader["Nombre_flor"]);
                    flores.Color = (string)reader["Color"];
                    flores.Precio = (decimal)reader["precio"];
                    flores.Descripcion = (string)reader["descripcion"];
                    listaFlores.Add(flores);
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                Bd.Close();
            }
            return listaFlores;
        }

        public void EditarUnaFlor(Models.Flores flores)
        {
            SqlConnection Bd = DbUtils.RecuperarConnection();

            try
            {
                string query = @"
                    UPDATE Flores
                    SET descripcion = @Descripcion, precio= @Precio
                    WHERE Id = @Id";
                SqlParameter id = new SqlParameter("Id", flores.Id);
                SqlParameter descripcion = new SqlParameter("Descripcion", flores.Descripcion);
                SqlParameter precio = new SqlParameter("Precio", flores.Precio);

                SqlCommand command = new SqlCommand(query, Bd);
                command.CommandType = CommandType.Text;

                command.Parameters.Add(id);
                command.Parameters.Add(descripcion);
                command.Parameters.Add(precio);

                command.ExecuteNonQuery();

            }
            catch
            {
                throw;
            }
            finally
            {
                Bd.Close();
            }
        }

        public Models.Flores RecuperarFlor(long id)
        {
            SqlConnection Bd = DbUtils.RecuperarConnection();

            try
            {
                string query = "SELECT Id, descripcion, precio, id_especie, id_color FROM Flores WHERE Id = @Id";

                SqlCommand command = new SqlCommand(query, Bd);
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@Id", id);

                SqlDataReader reader = command.ExecuteReader();

                Models.Flores flores = null;

                if (reader.Read())
                {
                    flores = new Models.Flores();
                    {
                        flores.Id = reader.GetInt32("Id");
                        flores.Descripcion = reader.GetString("descripcion");
                        flores.Precio = reader.GetDecimal("precio");
                        flores.Id_especie = reader.GetInt32("id_especie");
                        flores.Id_color = reader.GetInt32("id_color");
                    }
                }
                return flores;
            }
            catch
            {
                throw;
            }
            finally
            {
                Bd.Close();
            }
        }

        public void EliminarFlor(long id)
        {
            SqlConnection Bd = DbUtils.RecuperarConnection();

            try
            {
                string query = "DELETE FROM Flores WHERE Id = @Id";

                SqlCommand command = new SqlCommand(query, Bd);
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                Bd.Close();
            }
        }
    }

}
