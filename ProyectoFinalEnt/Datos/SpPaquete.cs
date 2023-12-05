using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration.UserSecrets;
using Microsoft.Data.SqlClient;
using ProyectoFinalEnt.Models;
using System.Data;
using Microsoft.Win32;

namespace ProyectoFinalEnt.Datos
{
    public class SpPaquete
    {
        public List<Paquete> Listar()
        {
            var cn = new Conexion();
            var list = new List<Paquete>();

            using (var conexion = new SqlConnection(cn.GetCadenaSql()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("Sp_Listar_P", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        list.Add(new Paquete
                        {
                            CodigoP = dr["codigo_P"].ToString(),
                            DescripP = dr["descrip_P"].ToString(),
                            NombreInstP = dr["nombre_Inst_P"].ToString(),
                            DirecInstP = dr["direc_Inst_P"].ToString(),
                        });
                    }
                }

            }
            return list;
        }

        public Paquete Buscar(string CdP)
        {
            var buscar = new Paquete();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.GetCadenaSql()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("Sp_Buscar_P", conexion);
                cmd.Parameters.AddWithValue("codigo_P", CdP);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        buscar.CodigoP = dr["codigo_P"].ToString();
                        buscar.DescripP = dr["descrip_P"].ToString();
                        buscar.NombreInstP= dr["nombre_Inst_P"].ToString();
                        buscar.DirecInstP = dr["direc_Inst_P"].ToString();
                      
                    }
                }
            }
            return buscar;
        }

        public bool Resgistrar(Paquete registrar)
        {
            bool respuesta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.GetCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("Sp_registrar_P", conexion);
                    cmd.Parameters.AddWithValue("codigo_P", registrar.CodigoP);
                    cmd.Parameters.AddWithValue("descrip_P", registrar.DescripP);
                    cmd.Parameters.AddWithValue("nombre_Inst_P", registrar.NombreInstP);
                    cmd.Parameters.AddWithValue("direc_Inst_P", registrar.DirecInstP);
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

        public bool Editar(Paquete editar)
        {
            bool respuesta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.GetCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("Sp_Editar_P", conexion);
                    cmd.Parameters.AddWithValue("codigo_P", editar.CodigoP);
                    cmd.Parameters.AddWithValue("descrip_P", editar.DescripP);
                    cmd.Parameters.AddWithValue("nombre_Inst_P", editar.NombreInstP);
                    cmd.Parameters.AddWithValue("direc_Inst_P", editar.DirecInstP);
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

        public bool Eliminar(string CdP)
        {
            bool respuesta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.GetCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("Sp_Eliminar_P", conexion);
                    cmd.Parameters.AddWithValue("codigo_P", CdP);
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
