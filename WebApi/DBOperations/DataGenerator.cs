
using Microsoft.EntityFrameworkCore;

namespace WebApi.DBOperations
{
    public class DataGenerator //Database Initial method
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if(context.Books.Any()){
                    return ;
                }else{
                    context.Books.AddRange(
                        new Book{
                            Id = 1 ,
                            Title = "Silmarillon",
                            GenreId = 1 , 
                            PageCount = 600,
                            PublishDate = new DateTime(1983,06,12)
                                        },

                        new Book{
                            Id = 2 ,
                            Title = "Hobbit",
                            GenreId = 1 , 
                            PageCount = 400,
                            PublishDate = new DateTime(1998,05,03)
                        },

                        new Book{
                            Id = 3 ,
                            Title = "LOTR",
                            GenreId = 1 ,    
                            PageCount = 550,
                            PublishDate = new DateTime(1996,08,30)
                        }
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}