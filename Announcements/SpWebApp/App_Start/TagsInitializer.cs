using Services;

namespace SpWebApp
{
    public class TagsInitializer
    {
        public static void Initialize(ITagService tagService)
        {
            tagService.FillTagsSet();
        }
    }
}