namespace CinemaAPI.Util
{
    public static class Settings
    {
        private static string _host;
        private static string _base;
        private static string _user;
        private static string _password;

        // Método para inicializar as configurações
        public static void Initialize(IConfiguration configuration)
        {
            _host = configuration["HOST"];
            _base = configuration["BASE"];
            _user = configuration["USER"];
            _password = configuration["PASSWORD"];
        }

        // Método para construir a string de conexão
        public static string GetConnectionString()
        {
            return $"Server={_host};Database={_base};User  Id={_user};Password={_password}; Trusted_Connection=False;";
        }
    }
}
