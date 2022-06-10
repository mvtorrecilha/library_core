using Library.Core.Models;
using Library.Core.Models.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Core.Interfaces.Services
{
    public interface IBookService
    {
        /// <summary>
        /// Return a list of books
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Book>> GetAllBooksAsync();

        /// <summary>
        /// Borrow a book
        /// </summary>
        /// <param name="borrowRequest">Request data to borrow a book: Bood Id and Student e-mail</param>
        /// <param name="action">Action: Borrow</param>
        /// <returns></returns>
        Task BorrowBookAsync(BorrowRequest borrowRequest, string action);
    }
}
