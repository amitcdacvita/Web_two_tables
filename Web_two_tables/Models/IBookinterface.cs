﻿using Microsoft.AspNetCore.Mvc;

namespace Web_two_tables.Models
{
    public interface IBookinterface
    {
        Task<ActionResult<Book>?> GetBook(int Id);
        Task<ActionResult<IEnumerable<Book>>> GetAllBook();
        Task<ActionResult<Book>> Add(Book book);
        Task<Book> Update(int id, Book book);
        Task<Book> Delete(int Id);
        ActionResult<IEnumerable<dynamic>> GetName(string name);

    }

}
