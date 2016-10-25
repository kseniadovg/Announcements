using EFModels;

namespace RepositoryAndUow
{
    public class UnitOfWork: IUnitOfWork
    {
        private IContextProvider contectProvider;

        private Context dbContext;

        public Context DbContext
        {
            get { return dbContext ?? (dbContext = contectProvider.GetContext()); }
        }

        #region Definition of repositories

        private GenericRepository<Announcement> announcementsRepository;

        #endregion

        public UnitOfWork(IContextProvider contectProvider)
        {
            this.contectProvider = contectProvider;
        }

        #region Get Repositories        

        IRepository<Announcement> IUnitOfWork.AnnouncementsRepository
        {
            get
            {
                if (announcementsRepository == null)
                {
                    announcementsRepository = new GenericRepository<Announcement>(contectProvider);
                }

                return announcementsRepository;
            }
        }

        
        #endregion
        
        void IUnitOfWork.SaveChanges()
        {
            DbContext.SaveChanges();
        }
    }
}
