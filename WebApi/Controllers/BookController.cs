using Microsoft.AspNetCore.Mvc;

namespace WebApi.AddControllers{

    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase{
       private static List<Book> BookList = new List<Book>(){
           new Book{
               Id = 1 ,
               Title = "Silmarillon",
               GenreId = 1 , //Personal Growth
               PageCount = 600,
               PublishDate = new DateTime(1983,06,12)
           },

           new Book{
               Id = 2 ,
               Title = "Hobbit",
               GenreId = 1 , //Personal Growth
               PageCount = 400,
               PublishDate = new DateTime(1998,05,03)
           },

           new Book{
               Id = 3 ,
               Title = "LOTR",
               GenreId = 1 , //Personal Growth
               PageCount = 550,
               PublishDate = new DateTime(1996,08,30)
           }
       };

        [HttpGet]
        public List<Book> GetBooks(){
            var bookList = BookList.OrderBy(x=>x.Id).ToList<Book>();
            return bookList;
        }

        [HttpGet("{id}")]
        public Book GetById(int id)
        {
            var book = BookList.Where(book => book.Id == id).SingleOrDefault();
            return book;
        }

        // [HttpGet]
        // public Book Get([FromQuery] string id)
        // {
        //     var book = BookList.Where(book => book.Id == Convert.ToInt32(id)).SingleOrDefault();
        //     return book;
        // }

    }

}