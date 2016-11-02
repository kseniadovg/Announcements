using EFModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Services
{
    public class AnnouncementService:IAnnouncementService
    {
        ITagService tagService;
        IContextProvider contextProvider;
        Context context;
        protected Context DbContext
        {
            get { return context ?? (context = contextProvider.GetContext()); }

        }

        public AnnouncementService(IContextProvider contextProvider, ITagService tagService)
        {
            this.contextProvider = contextProvider;
            this.tagService = tagService;
        }

        public void Add(Announcement announcement)
        {
            DbContext.Announcements.Add(announcement);
            if (announcement.Tags.Length > 0)
            {
                tagService.UpdateTagsSet(announcement.Tags);
            }
            DbContext.SaveChanges();
        }

        public void Update(Announcement announcement)
        {
            DbContext.Entry(announcement).State = EntityState.Modified;
            if (announcement.Tags.Length > 0)
            {
                tagService.UpdateTagsSet(announcement.Tags);
            }
            DbContext.SaveChanges();
        }

        public void Delete(Announcement announcement)
        {
            DbContext.Entry(announcement).State = EntityState.Deleted;
            DbContext.SaveChanges();
        }

        public Announcement GetById(int id)
        {
            return DbContext.Announcements.Find(id);
        }

        public IEnumerable<Announcement> GetAll()
        {
            return DbContext.Announcements;
        }

        public Announcement Get(Expression<Func<Announcement, bool>> condition)
        {
            return DbContext.Announcements.Where(condition).FirstOrDefault();
        }

        public IEnumerable<Announcement> GetMany(Expression<Func<Announcement, bool>> condition)
        {
            return DbContext.Announcements.Where(condition).ToList();
        }

        public IEnumerable<Announcement> GetOwnAnnouncements(string authorId)
        {
            return DbContext.Announcements.Where(a => a.AuthorId == authorId).ToList();
        }

        public IEnumerable<Announcement> GetFriendsAnnouncements(IEnumerable<string> Ids)
        {
            List<Announcement> list = new List<Announcement>();
            foreach(var id in Ids )
            {
                list.AddRange(DbContext.Announcements.Where(a => a.AuthorId == id));
            }
            return list;
        }

        public IEnumerable<Announcement> GetByTag(string tag)
        {
            List<Announcement> list = new List<Announcement>();
            if(TagsSingletonContainer.Tags.Contains(tag.ToLower()))
            {
                foreach(var announcement in DbContext.Announcements)
                {
                    string[] tags = announcement.Tags.Split(';');
                    for(int i=0;i<tags.Length;i++)
                    {
                        tags[i] = tags[i].ToLower();
                    }
                    if(tags.Contains(tag))
                    {
                        list.Add(announcement);
                    }
                }
            }
            else
            {
                return null;
            }
            
            return list;
        }
    }
}
