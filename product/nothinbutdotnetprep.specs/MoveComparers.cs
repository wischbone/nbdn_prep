using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nothinbutdotnetprep.collections
{
    public class MoveComparerTitleDescending : IComparer<Movie>
    {
        #region IComparer<Movie> Members

        public int Compare(Movie x, Movie y)
        {
            return x.title.CompareTo(y.title);
        }

        #endregion
    }
}
