using BooksApp.Domain.RepositoryInterfaces;

namespace BooksApp.Domain
{
    public interface IUnitOfWork
    {
        IAuthorRepository AuthorRepository { get; }
        IBookRepository BookRepository { get; }
        IPublishingHouseRepository PublishingHouseRepository { get; }
        void Save();
        Task SaveAsync();
    }
}
