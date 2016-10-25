using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class TagsSingletonContainer
    {
        private volatile TagsSingletonContainer context = null;
        private static object sync = new Object();

        public TagsSingletonContainer GetContext()
        {
            if (context == null)
            {
                lock (sync)
                {
                    if (context == null)
                    {
                        context = new TagsSingletonContainer();
                    }
                }
            }

            return context;
        }
    }
}
