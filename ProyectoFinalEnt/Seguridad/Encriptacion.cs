using System.Security.Cryptography;
using System.Text;

namespace ProyectoFinalEnt.Seguridad
{
    public class Encriptacion
    {
        public static string EncriptarClave(string clave)
        {
            StringBuilder stringBuilder = new StringBuilder();

            using (SHA256 hash = SHA256Managed.Create()) 
            {
            
                Encoding encoding = Encoding.UTF8;
                byte[] result = hash.ComputeHash(encoding.GetBytes(clave));
                foreach (byte b in result) 
                {
                    stringBuilder.Append(b.ToString("x2"));
                }

            }
            return stringBuilder.ToString();
        }


    }
}
