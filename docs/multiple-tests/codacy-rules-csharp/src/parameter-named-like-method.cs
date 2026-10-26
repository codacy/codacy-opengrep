namespace Tests.Naming
{
    public class Auth
    {
        public void Login(string login) // Noncompliant
        {
        }

        public void Logout(string user, int LOGOUT) // Noncompliant
        {
            Login(user);
        }

        public void Connect(string host)
        {
        }
    }
}
