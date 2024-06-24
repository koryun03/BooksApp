using BooksApp.Domain.Dto.Author;
using BooksApp.Domain.Dto.Book;
using BooksApp.Domain.Entities;
using BooksApp.Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace BooksApp.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationContext _context;
        public BookRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(BookInsertDto dto)
        {
            var book = new Book { Name = dto.Name, Price = dto.Price, AuthorId = dto.AuthorId };
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
            return book.Id;
        }

        public async Task<int> AddBookAndAuthorAsync(BookAndAuthorInsertDto dto)
        {
            var author = new Author { LastName = dto.Author.LastName, FirstName = dto.Author.FirstName };
            await _context.Authors.AddAsync(author);
            await _context.SaveChangesAsync();

            var book = new Book { Name = dto.Name, Price = dto.Price, AuthorId = author.Id };
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
            return book.Id;
        }

        public async Task UpdateAsync(BookDto dto)
        {
            var book = await _context.Books.FirstOrDefaultAsync(p => p.Id == dto.Id);

            if (book == null)
            {
                throw new ArgumentException("wrongId");
            }

            book.Name = dto.Name;
            book.Price = dto.Price;
            book.AuthorId = dto.AuthorId;
            _context.Books.Update(book);
        }

        public async Task DeleteAsync(int id)
        {
            var book = await _context.Books.FirstOrDefaultAsync(p => p.Id == id);
            if (book == null)
            {
                throw new ArgumentException("wrongId");
            }
            _context.Books.Remove(book);
        }

        public async Task<IEnumerable<BookAuthorDto>> GetAllBooksAsync()
        {
            return await _context.Books
                .Include(i => i.Author)
                .Select(i => new BookAuthorDto
                {
                    Id = i.Id,
                    Name = i.Name,
                    Price = i.Price,
                    AuthorId = i.Author.Id,
                    Author = new AuthorDto
                    {
                        Id = i.Author.Id,
                        FirstName = i.Author.FirstName,
                        LastName = i.Author.LastName,
                    }
                }).AsNoTracking().ToListAsync();
        }

        public async Task<BookAuthorDto> GetBookByIdAsync(int id)
        {
            var dto = await _context.Books
                .Include(i => i.Author)
                .Select(i => new BookAuthorDto
                {
                    Id = i.Id,
                    Name = i.Name,
                    Price = i.Price,
                    AuthorId = i.Author.Id,
                    Author = new AuthorDto
                    {
                        Id = i.Author.Id,
                        FirstName = i.Author.FirstName,
                        LastName = i.Author.LastName,
                    }
                }).AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);

            if (dto == null)
            {
                throw new ArgumentException("wrongId");
            }

            return dto;
        }

    }
}
