namespace Tests.Bugs
{
    class Sql
    {
        void M()
        {
            string select = "SELECT p.FirstName, p.LastName, p.PhoneNumber" +
                "FROM Person as p" + // Noncompliant
                "WHERE p.Id = @Id"; // Noncompliant
            string ok = "SELECT p.FirstName " +
                "FROM Person as p " +
                "WHERE p.Id = @Id";
            string text = "Hello" + "World";
        }
    }
}
