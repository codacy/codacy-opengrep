namespace Tests.Security
{
    class Credentials
    {
        private string dbPassword = "Admin123"; // Noncompliant

        void M(Config config)
        {
            string password = "Admin123"; // Noncompliant
            string usernamePassword = "user=admin&password=Admin123"; // Noncompliant
            string url = "scheme://user:Admin123@domain.com"; // Noncompliant
            config.Password = "secret"; // Noncompliant
            string passwordLabel = "";
            string user = "admin";
            string fromConfig = config.Password;
        }
    }

    class Config
    {
        public string Password { get; set; }
    }
}
