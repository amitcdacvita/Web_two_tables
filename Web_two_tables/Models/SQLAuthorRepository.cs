using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_two_tables.Models;


namespace WebAPITwoTable.Models
{
    public class SQLAuthorRepository : IAuthorinterface
    {
        private readonly AppdbContext context;

        public SQLAuthorRepository(AppdbContext context)
        {
            this.context = context;
        }
        public async Task<ActionResult<Author>> Add(Author author)
        {
            context.Authors.Add(author);
            await context.SaveChangesAsync();
            return author;
        }

       

        public async Task<Author> Delete(int Id)
        {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            Author author = context.Authors.Find(Id);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            if (author != null)
            {
                context.Authors.Remove(author);
                await context.SaveChangesAsync();
            }
#pragma warning disable CS8603 // Possible null reference return.
            return author;
#pragma warning restore CS8603 // Possible null reference return.
        }

       

#pragma warning disable CS8613 // Nullability of reference types in return type doesn't match implicitly implemented member.
        public async Task<ActionResult<IEnumerable<Author>?>> GetAllAuthor()
#pragma warning restore CS8613 // Nullability of reference types in return type doesn't match implicitly implemented member.
        {
            if (context.Authors == null)
            {
#pragma warning disable CS8603 // Possible null reference return.
                return null;
#pragma warning restore CS8603 // Possible null reference return.
            }

            return await context.Authors.ToListAsync();
        }

        public Task<ActionResult<Author>?> GetAuthor(int Id)
        {
            throw new NotImplementedException();
        }

        public ActionResult<IEnumerable<dynamic>> GetName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<Author> Update(int id, Author author)
        {
            throw new NotImplementedException();
        }

        public Task Update(int id, object author)
        {
            throw new NotImplementedException();
        }

        Task<Author> IAuthorinterface.Delete(int Id)
        {
            throw new NotImplementedException();
        }
    }
}


