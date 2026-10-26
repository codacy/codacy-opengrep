using System.Web;

namespace Tests.Security
{
    class Cookies
    {
        void M()
        {
            HttpCookie myCookie = new HttpCookie("Sensitive cookie");
            myCookie.HttpOnly = false; // Noncompliant

            HttpCookie safe = new HttpCookie("Sensitive cookie");
            safe.HttpOnly = true;
        }
    }
}
