using BooksApp.Domain;
using BooksApp.Domain.RepositoryInterfaces;
using BooksApp.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace BooksApp.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;
        private IAuthorRepository _authRepository;
        private IBookRepository _bookRepository;
        private IPublishingHouseRepository _publishingHouseRepository;
        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
        }

        public IAuthorRepository AuthorRepository
        {
            get { return _authRepository ?? (_authRepository = new AuthorRepository(_context)); }
        }

        public IBookRepository BookRepository
        {
            get { return _bookRepository ?? (_bookRepository = new BookRepository(_context)); }
        }

        public IPublishingHouseRepository PublishingHouseRepository
        {
            get { return _publishingHouseRepository ?? (_publishingHouseRepository = new PublishingHouseRepository(_context)); }
        }

        #region save

        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                DbUpdateExceptionHandler(ex);
            }
        }

        public async Task SaveAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                DbUpdateExceptionHandler(ex);
            }
        }

        private void DbUpdateExceptionHandler(DbUpdateException ex)
        {
            var builder = new StringBuilder();

            foreach (var result in ex.Entries)
            {
                builder.AppendFormat("Type: {0} was part of the problem. ", result.Entity.GetType().Name);
            }

            throw new Exception(builder.ToString(), ex);
        }
        #endregion

        #region Diposable   

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
