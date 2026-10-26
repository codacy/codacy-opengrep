using System.Web;

namespace Tests.Security
{
    class Cookies
    {
        void M()
        {
            HttpCookie myCookie = new HttpCookie("Sensitive cookie");
            myCookie.Secure = false; // Noncompliant

            HttpCookie other = new HttpCookie("Sensitive cookie"); // Noncompliant
            other.Value = "x";

            HttpCookie safe = new HttpCookie("Sensitive cookie");
            safe.Secure = true;
        }
    }
}
