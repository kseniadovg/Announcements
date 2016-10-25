using EFModels;

namespace RepositoryAndUow
{
    public interface IUnitOfWork
    {
        #region Repositories

        IRepository<Announcement> AnnouncementsRepository { get; }
        
        #endregion 

        void SaveChanges();
    }
}
