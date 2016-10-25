using EFModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class AnnouncementService
    {
        IContextProvider contextProvider;
        Context context;
        protected Context DbContext
        {
            get { return context ?? (context = contextProvider.GetContext()); }

        }

        public AnnouncementService(IContextProvider contextProvider)
        {
            this.contextProvider = contextProvider;
        }

        void Add(Announcement announcement)
        {
            DbContext.Announcements.Add(announcement);
            DbContext.SaveChanges();
        }
        
        void Update(Announcement announcement)
        {
            DbContext.Entry(announcement).State = EntityState.Modified;
            DbContext.SaveChanges();
        }

        void Delete(Announcement announcement)
        {
            DbContext.Entry(announcement).State = EntityState.Deleted;
            DbContext.SaveChanges();
        }

        Announcement GetById(int id)
        {
            return DbContext.Announcements.Find(id);
        }

        IEnumerable<Announcement> GetAll()
        {
            return DbContext.Announcements;
        }

        Announcement Get(Expression<Func<Announcement, bool>> condition)
        {
            return DbContext.Announcements.Where(condition).FirstOrDefault();
        }

        IEnumerable<Announcement> GetMany(Expression<Func<Announcement, bool>> condition)
        {
            return DbContext.Announcements.Where(condition).ToList();
        }
    }
}
