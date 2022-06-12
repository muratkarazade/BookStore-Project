using Microsoft.AspNetCore.Mvc;
using WebApi.DBOperations;

namespace WebApi.AddControllers{

    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase{
   
        private readonly BookStoreDbContext _context;

        public BookController(BookStoreDbContext context)
        {
            _context = context;
        }


        // GETIRME-ALMA ISLEMLERI
        [HttpGet]
        public List<Book> GetBooks(){
            var bookList = _context.Books.OrderBy(x=>x.Id).ToList<Book>();
            return bookList;
        }

        // ID ILE GETİRME ISLEMI
        [HttpGet("{id}")]
        public Book GetById(int id)
        {
            var book = _context.Books.Where(book => book.Id == id).SingleOrDefault();
            return book;
        }

        // [HttpGet]
        // public Book Get([FromQuery] string id)
        // {
        //     var book = BookList.Where(book => book.Id == Convert.ToInt32(id)).SingleOrDefault();
        //     return book;
        // }

        //EKLEME ISLEMLERI
        [HttpPost]
        public IActionResult AddBook([FromBody] Book newBook){
            var book = _context.Books.SingleOrDefault(x => x.Title == newBook.Title);

        if(book is not null){
            return BadRequest();
        }else{
            _context.Books.Add(newBook);
            _context.SaveChanges();
            return Ok();
            
        }

        }

        //GUNCELLEME ISLEMLERI
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] Book updateBook){
            var book = _context.Books.SingleOrDefault(x => x.Id == id);
            if(book is  null){
                return BadRequest();
            }else{
                book.GenreId = updateBook.GenreId != default ? updateBook.GenreId : book.GenreId;
                book.PageCount = updateBook.PageCount != default ? updateBook.PageCount : book.PageCount;   
                book.PublishDate = updateBook.PublishDate != default ? updateBook.PublishDate : book.PublishDate;
                book.Title = updateBook.Title != default ? updateBook.Title: book.Title;

                _context.SaveChanges();
                return Ok(); 
            }         
        }  

        //SILME ISLEMLERI
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id){
            var book = _context.Books.SingleOrDefault(x => x.Id == id);
            if(book is null){
                return BadRequest();
            }else
            {
               _context.Books.Remove(book);
               _context.SaveChanges();
               return Ok(); 
            }
        }
    }
}













 //    private static List<Book> BookList = new List<Book>(){
    //        new Book{
    //            Id = 1 ,
    //            Title = "Silmarillon",
    //            GenreId = 1 , 
    //            PageCount = 600,
    //            PublishDate = new DateTime(1983,06,12)
    //        },

    //        new Book{
    //            Id = 2 ,
    //            Title = "Hobbit",
    //            GenreId = 1 , 
    //            PageCount = 400,
    //            PublishDate = new DateTime(1998,05,03)
    //        },

    //        new Book{
    //            Id = 3 ,
    //            Title = "LOTR",
    //            GenreId = 1 ,    
    //            PageCount = 550,
    //            PublishDate = new DateTime(1996,08,30)
    //        }
    //    };