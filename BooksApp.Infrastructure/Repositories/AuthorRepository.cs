using BooksApp.Domain.Dto.Author;
using BooksApp.Domain.Dto.Book;
using BooksApp.Domain.Entities;
using BooksApp.Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace BooksApp.Infrastructure.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ApplicationContext _context;
        public AuthorRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(AuthorInsertDto dto)
        {
            var author = new Author { FirstName = dto.FirstName, LastName = dto.LastName };
            await _context.Authors.AddAsync(author);
            await _context.SaveChangesAsync();
            return author.Id;
        }

        public async Task UpdateAsync(AuthorDto dto)
        {
            var author = await _context.Authors.FirstOrDefaultAsync(p => p.Id == dto.Id);

            if (author == null)
            {
                throw new ArgumentException("wrongId");
            }

            author.FirstName = dto.FirstName;
            author.LastName = dto.LastName;

            _context.Authors.Update(author);
        }

        public async Task DeleteAsync(int id)
        {
            var author = await _context.Authors.FirstOrDefaultAsync(p => p.Id == id);
            if (author == null)
            {
                throw new ArgumentException("wrongId");
            }
            _context.Authors.Remove(author);
        }

        public async Task<IEnumerable<AuthorDto>> GetAllAsync()
        {
            return await _context.Authors.AsNoTracking().Select(i => new AuthorDto
            {
                Id = i.Id,
                FirstName = i.FirstName,
                LastName = i.LastName
            }).ToListAsync();
        }

        public async Task<AuthorDto> GetByIdAsync(int id)
        {
            var author = await _context.Authors.AsNoTracking().Select(i => new AuthorDto
            {
                Id = i.Id,
                FirstName = i.FirstName,
                LastName = i.LastName
            }).FirstOrDefaultAsync(p => p.Id == id);

            if (author == null)
            {
                throw new ArgumentException("wrongId");
            }

            return author;
        }

        public async Task<AuthorsBooksDto> GetAuthorsBooksById(int id)
        {
            var authorsBooks = await _context.Authors
                .Include(i => i.Books)
                .Select(i => new AuthorsBooksDto
                {
                    Id = i.Id,
                    FirstName = i.FirstName,
                    LastName = i.LastName,
                    Books = i.Books.Select(p => new BookResponseDto
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Price = p.Price
                    }).ToList()
                }).AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);

            if (authorsBooks == null)
            {
                throw new ArgumentException("wrongId");
            }

            return authorsBooks;
        }
    }
}
