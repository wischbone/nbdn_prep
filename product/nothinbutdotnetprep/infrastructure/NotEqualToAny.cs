using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nothinbutdotnetprep.infrastructure
{
    public class NotEqualToAny<T> : Criteria<T>
    {
        IList<T> items;

        public NotEqualToAny(params T[] items)
        {
            this.items = new List<T>(items);
        }

        public bool matches(T item)
        {
            return !items.Contains(item);
        }
    }
}
