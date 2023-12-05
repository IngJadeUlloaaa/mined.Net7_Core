namespace ProyectoFinalEnt.Datos
{
    public class Conexion
    {
        private string cadenaSql = string.Empty;

        public Conexion()
        {
            var builder =
                new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();

            cadenaSql = builder.GetSection("ConnectionStrings:Conexion").Value;
        }

        public string GetCadenaSql()
        {
            return cadenaSql;
        }
    }
}
