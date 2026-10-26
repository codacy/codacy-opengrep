using Microsoft.EntityFrameworkCore;

namespace Tests.Security
{
    class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password="); // Noncompliant
            optionsBuilder.UseSqlServer("Server=myServerAddress;Database=myDataBase;Integrated Security=True");
            optionsBuilder.UseSqlServer("Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password=" + GetPassword());
        }

        string GetPassword() => System.Environment.GetEnvironmentVariable("DB_PASSWORD");
    }
}
