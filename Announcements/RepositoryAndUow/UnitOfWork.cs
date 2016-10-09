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
        private GenericRepository<Category> categoriesRepository;
        private GenericRepository<Tag> tagsRepository;

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

        IRepository<Category> IUnitOfWork.CategoriesRepository
        {
            get
            {
                if (categoriesRepository == null)
                {
                    categoriesRepository = new GenericRepository<Category>(contectProvider);
                }

                return categoriesRepository;
            }
        }

        IRepository<Tag> IUnitOfWork.TagsRepository
        {
            get
            {
                if (tagsRepository == null)
                {
                    tagsRepository = new GenericRepository<Tag>(contectProvider);
                }

                return tagsRepository;
            }
        }

        #endregion
        
        void IUnitOfWork.SaveChanges()
        {
            DbContext.SaveChanges();
        }
    }
}
