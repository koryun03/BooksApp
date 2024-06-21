using BooksApp.Domain.RepositoryInterfaces;

namespace BooksApp.Domain
{
    public interface IUnitOfWork
    {
        IAuthRepository AuthRepository { get; }
        void Save();
        Task SaveAsync();
    }
}
