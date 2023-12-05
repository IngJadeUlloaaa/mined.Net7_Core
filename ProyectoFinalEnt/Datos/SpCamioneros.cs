using Microsoft.Data.SqlClient;
using ProyectoFinalEnt.Models;
using System.Data;

namespace ProyectoFinalEnt.Datos
{
    public class SpCamioneros
    {
        public List<Camionero> Listar()
        {
            var cn = new Conexion();
            var list = new List<Camionero>();

            using (var conexion = new SqlConnection(cn.GetCadenaSql()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("Sp_Listar_C", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        list.Add(new Camionero
                        {
                            IdC = Convert.ToInt32(dr["id_C"]),
                            CedulaC = dr["cedula_C"].ToString(),
                            LicenciaC = dr["licencia_C"].ToString(),
                            NombreC = dr["nombre_C"].ToString(),
                            ApellidoC = dr["apellido_C"].ToString(),
                            CorreoC = dr["Correo_C"].ToString(),
                            ClaveC = dr["clave_C"].ToString(),
                            CodigoPpk = dr["codigo_Ppk"].ToString(),
                            IdDpk = Convert.ToInt32(dr["id_Dpk"])
                        });
                    }
                }

            }
            return list;
        }

        public Camionero Buscar(int IdC)
        {
            var buscar = new Camionero();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.GetCadenaSql()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("Sp_Buscar_C", conexion);
                cmd.Parameters.AddWithValue("id_C", IdC);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        buscar.IdC = Convert.ToInt32(dr["id_C"]);
                        buscar.CedulaC = dr["cedula_C"].ToString();
                        buscar.LicenciaC = dr["licencia_C"].ToString();
                        buscar.NombreC = dr["nombre_C"].ToString();
                        buscar.ApellidoC = dr["apellido_C"].ToString();
                        buscar.CorreoC = dr["Correo_C"].ToString();
                        buscar.ClaveC = dr["clave_C"].ToString();
                        buscar.CodigoPpk = dr["codigo_Ppk"].ToString();
                        buscar.IdDpk = Convert.ToInt32(dr["id_Dpk"]);
                    }

                }
            }
            return buscar;
        }

        public bool Editar(Camionero editar)
        {
            bool respuesta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.GetCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("Sp_Editar_C", conexion);
                    cmd.Parameters.AddWithValue("id_C", editar.IdC);
                    cmd.Parameters.AddWithValue("cedula_C", editar.CedulaC);
                    cmd.Parameters.AddWithValue("licencia_C", editar.LicenciaC);
                    cmd.Parameters.AddWithValue("nombre_C", editar.NombreC);
                    cmd.Parameters.AddWithValue("apellido_C", editar.ApellidoC);
                    cmd.Parameters.AddWithValue("Correo_C", editar.CorreoC);
                    cmd.Parameters.AddWithValue("clave_C", editar.ClaveC);
                    cmd.Parameters.AddWithValue("codigo_Ppk", editar.CodigoPpk);
                    cmd.Parameters.AddWithValue("id_Dpk", editar.IdDpk);
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

        public bool Eliminar(int IdC)
        {
            bool respuesta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.GetCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("Sp_Eliminar_C", conexion);
                    cmd.Parameters.AddWithValue("id_C", IdC);
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
