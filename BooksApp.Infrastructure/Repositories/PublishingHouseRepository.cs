using BooksApp.Domain.Dto.Author;
using BooksApp.Domain.Dto.Book;
using BooksApp.Domain.Dto.PublishingHouse;
using BooksApp.Domain.Entities;
using BooksApp.Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace BooksApp.Infrastructure.Repositories
{
    public class PublishingHouseRepository : IPublishingHouseRepository
    {
        private readonly ApplicationContext _context;
        public PublishingHouseRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(PublishingHouseInsertDto dto)
        {
            var ph = new PublishingHouse { PublishingHouseName = dto.Name, Count = dto.Count, BookId = dto.BookId };
            await _context.PublishingHouses.AddAsync(ph);
            await _context.SaveChangesAsync();
            return ph.Id;
        }

        public async Task UpdateAsync(PublishingHouseDto dto)
        {
            var ph = await _context.PublishingHouses.FirstOrDefaultAsync(p => p.Id == dto.Id);

            if (ph == null)
            {
                throw new ArgumentException("wrongId");
            }

            ph.PublishingHouseName = dto.Name;
            ph.Count = dto.Count;
            ph.BookId = dto.BookId;
            _context.PublishingHouses.Update(ph);
        }

        public async Task DeleteAsync(int id)
        {
            var ph = await _context.PublishingHouses.FirstOrDefaultAsync(p => p.Id == id);

            if (ph == null)
            {
                throw new ArgumentException("wrongId");
            }

            _context.PublishingHouses.Remove(ph);
        }

        public async Task<IEnumerable<PublishingHouseBookDto>> GetAllAsync()
        {
            return await _context.PublishingHouses
                 .Include(i => i.Book).ThenInclude(i => i.Author)
                 .Select(i => new PublishingHouseBookDto
                 {
                     Id = i.Id,
                     Name = i.PublishingHouseName,
                     Count = i.Count,
                     Book = new BookAuthorDto
                     {
                         Name = i.Book.Name,
                         Price = i.Book.Price,
                         Author = new AuthorDto
                         {
                             Id = i.Book.Author.Id,
                             FirstName = i.Book.Author.FirstName,
                             LastName = i.Book.Author.LastName,
                         }
                     }
                 }).AsNoTracking().ToListAsync();
        }

        public async Task<PublishingHouseBookDto> GetByIdAsync(int id)
        {
            var dto = await _context.PublishingHouses
               .Include(i => i.Book).ThenInclude(i => i.Author)
               .Select(i => new PublishingHouseBookDto
               {
                   Id = i.Id,
                   Name = i.PublishingHouseName,
                   Count = i.Count,
                   Book = new BookAuthorDto
                   {
                       Name = i.Book.Name,
                       Price = i.Book.Price,
                       Author = new AuthorDto
                       {
                           Id = i.Book.Author.Id,
                           FirstName = i.Book.Author.FirstName,
                           LastName = i.Book.Author.LastName,
                       }
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
