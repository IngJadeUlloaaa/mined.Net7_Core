using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration.UserSecrets;
using Microsoft.Data.SqlClient;
using ProyectoFinalEnt.Models;
using System.Data;

namespace ProyectoFinalEnt.Datos
{
    public class SpDirector
    {
        public List<Director> Listar()
        {
            var cn = new Conexion();
            var list = new List<Director>();

            using (var conexion = new SqlConnection(cn.GetCadenaSql()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("Sp_Listar_D", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        list.Add(new Director
                        {
                            IdD = Convert.ToInt32(dr["id_D"]),
                            CedulaD = dr["cedula_D"].ToString(),
                            NombreD = dr["nombre_D"].ToString(),
                            ApellidoD = dr["apellido_D"].ToString(),
                            NombreInstD = dr["nombre_Inst_D"].ToString(),
                            CorreoD = dr["correo_D"].ToString(),
                            ClaveD = dr["clave_D"].ToString()
                        });
                    }
                }

            }
            return list;
        }

        public Director Buscar(int IdD)
        {
            var buscar = new Director();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.GetCadenaSql()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("Sp_Buscar_D", conexion);
                cmd.Parameters.AddWithValue("id_D", IdD);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        buscar.IdD = Convert.ToInt32(dr["id_D"]);
                        buscar.CedulaD = dr["cedula_D"].ToString();
                        buscar.NombreD = dr["nombre_D"].ToString();
                        buscar.ApellidoD = dr["apellido_D"].ToString();
                        buscar.NombreInstD = dr["nombre_Inst_D"].ToString();
                        buscar.CorreoD = dr["correo_D"].ToString();
                        buscar.ClaveD = dr["clave_D"].ToString();
                    }
                }
            }
            return buscar;
        }

        /*public bool Resgistrar(Director registrar)
        {
            bool respuesta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.GetCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("Sp_registrar_D", conexion);
                    cmd.Parameters.AddWithValue("cedula_D", registrar.CedulaD);
                    cmd.Parameters.AddWithValue("nombre_D", registrar.NombreD);
                    cmd.Parameters.AddWithValue("apellido_D", registrar.ApellidoD);
                    cmd.Parameters.AddWithValue("nombre_Inst_D", registrar.NombreInstD);
                    cmd.Parameters.AddWithValue("correo_D", registrar.CorreoD);
                    cmd.Parameters.AddWithValue("clave_D", registrar.ClaveD);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }

                respuesta = true;

            }
            catch (Exception e)
            {
                string error = e.Message;
                respuesta = false;
            }

            return respuesta;
        }*/

        public bool Editar(Director editar)
        {
            bool respuesta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.GetCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("Sp_Editar_D", conexion);
                    cmd.Parameters.AddWithValue("id_D", editar.IdD);
                    cmd.Parameters.AddWithValue("cedula_D", editar.CedulaD);
                    cmd.Parameters.AddWithValue("nombre_D", editar.NombreD);
                    cmd.Parameters.AddWithValue("apellido_D", editar.ApellidoD);
                    cmd.Parameters.AddWithValue("nombre_Inst_D", editar.NombreInstD);
                    cmd.Parameters.AddWithValue("correo_D", editar.CorreoD);
                    cmd.Parameters.AddWithValue("clave_D", editar.ClaveD);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

                }
                respuesta = true;

            }
            catch (Exception e)
            {
                string error = e.Message;
                respuesta = false;
            }
            return respuesta;
        }

        public bool Eliminar(int IdD)
        {
            bool respuesta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.GetCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("Sp_Eliminar_D", conexion);
                    cmd.Parameters.AddWithValue("id_D", IdD);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;

            }
            catch (Exception e)
            {
                string error = e.Message;
                respuesta = false;
            }

            return respuesta;
        }

    }
}
