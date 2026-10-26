using System.Data;
using System.Globalization;

namespace MyLibrary
{
    public class Foo
    {
        public DataTable CreateTable()
        {
            var table = new DataTable("Customers"); // Noncompliant
            return table;
        }

        public DataTable CreateGood()
        {
            var table = new DataTable("Customers");
            table.Locale = CultureInfo.InvariantCulture;
            return table;
        }
    }
}
