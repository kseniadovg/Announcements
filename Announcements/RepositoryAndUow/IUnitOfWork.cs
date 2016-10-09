using EFModels;

namespace RepositoryAndUow
{
    public interface IUnitOfWork
    {
        #region Repositories

        IRepository<Announcement> AnnouncementsRepository { get; }

        IRepository<Category> CategoriesRepository { get; }

        IRepository<Tag> TagsRepository { get; }

        #endregion 

        void SaveChanges();
    }
}
