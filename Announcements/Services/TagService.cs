using EFModels;

namespace Services
{
    public class TagService:ITagService
    {
        IContextProvider contextProvider;
        Context context;
        protected Context DbContext
        {
            get { return context ?? (context = contextProvider.GetContext()); }

        }

        public TagService(IContextProvider contextProvider)
        {
            this.contextProvider = contextProvider;
        }

        public void FillTagsSet()
        {
            foreach(var announcement in DbContext.Announcements)
            {
                UpdateTagsSet(announcement.Tags);
            }
        }

        public void UpdateTagsSet(string tags)
        {
            string[] Tags = tags.Split(';');
            foreach (string tag in Tags)
            {
                TagsSingletonContainer.Tags.Add(tag.ToLower());
            }
        }
    }
}
