using Microsoft.EntityFrameworkCore;

namespace WebApi.DBOperations{

    public class BookStoreDbContext : DbContext
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options){  // Default Constructor Method
            if (options is null)
            {
                throw new ArgumentNullException(nameof(options));
            }
        }
        public DbSet<Book> Books { get; set; }
    }

}