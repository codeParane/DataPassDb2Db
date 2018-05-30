using Microsoft.EntityFrameworkCore;


namespace EFCoreDemo
{
    public class From_Context : DbContext
    {
        public DbSet<Book> tb_data { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost\sqlexpress;Database=from_db;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }

    public class To_Context : DbContext
    {
        public DbSet<Book> tb_data { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost\sqlexpress;Database=to_db;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}