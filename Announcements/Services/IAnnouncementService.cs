using EFModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Services
{
    public interface IAnnouncementService
    {
        void Add(Announcement announcement);

        void Update(Announcement announcement);

        void Delete(Announcement announcement);

        Announcement GetById(int id);

        IEnumerable<Announcement> GetAll();

        Announcement Get(Expression<Func<Announcement, bool>> condition);

        IEnumerable<Announcement> GetMany(Expression<Func<Announcement, bool>> condition);

        IEnumerable<Announcement> GetOwnAnnouncements(string authorId);

        IEnumerable<Announcement> GetFriendsAnnouncements(IEnumerable<string> Ids);

        IEnumerable<Announcement> GetByTag(string tag);
    }
}
