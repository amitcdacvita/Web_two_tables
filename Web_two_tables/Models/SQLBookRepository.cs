namespace Web_two_tables.Models
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using WebAPITwoTable.Models;

    namespace WebAPITwoTable.Models
    {
        public class SQLBookRepository : IBookinterface
        {
            private readonly AppdbContext context;

            public SQLBookRepository(AppdbContext context)
            {
                this.context = context;
            }
            public async Task<ActionResult<Book>> Add(Book book)
            {
                context.Books.Add(book);
                await context.SaveChangesAsync();
                return book;
            }

            public async Task<Book> Delete(int Id)
            {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                Book book = context.Books.Find(Id);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                if (book != null)
                {
                    context.Books.Remove(book);
                    await context.SaveChangesAsync();
                }
#pragma warning disable CS8603 // Possible null reference return.
                return book;
#pragma warning restore CS8603 // Possible null reference return.
            }

#pragma warning disable CS8613 // Nullability of reference types in return type doesn't match implicitly implemented member.
            public async Task<ActionResult<IEnumerable<Book>?>> GetAllBook()
#pragma warning restore CS8613 // Nullability of reference types in return type doesn't match implicitly implemented member.
            {
                if (context.Books == null)
                {
#pragma warning disable CS8603 // Possible null reference return.
                    return null;
#pragma warning restore CS8603 // Possible null reference return.
                }

                return await context.Books.ToListAsync();
            }

            public Task<ActionResult<Book>?> GetBook(int Id)
            {
                throw new NotImplementedException();
            }

            public ActionResult<IEnumerable<dynamic>> GetName(string name)
            {
                throw new NotImplementedException();
            }

            public Task<Book> Update(int id, Book book)
            {
                throw new NotImplementedException();
            }

        }
    }
}
