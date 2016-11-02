using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class TagsSingletonContainer
    {
        private static volatile TagsSingletonContainer tagsContainer = null;
        private static object sync = new object();

        HashSet<string> tags = new HashSet<string>();

        public static TagsSingletonContainer GetTagsContainer()
        {
            if (tagsContainer == null)
            {
                lock (sync)
                {
                    if (tagsContainer == null)
                    {
                        tagsContainer = new TagsSingletonContainer();
                    }
                }
            }

            return tagsContainer;
        }

        public static HashSet<string> Tags
        {
            get
            {
                return GetTagsContainer().tags;
            }
            set
            {
                GetTagsContainer().tags = value;
            }
        }
    }
}
