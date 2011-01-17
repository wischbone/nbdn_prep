using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nothinbutdotnetprep.collections
{
    public class MovieComparerTitleDescending : IComparer<Movie>
    {
        #region IComparer<Movie> Members

        public int Compare(Movie x, Movie y)
        {
            return y.title.CompareTo(x.title);
        }

        #endregion
    }

    public class MovieComparerTitleAscending : IComparer<Movie>
    {
        #region IComparer<Movie> Members

        public int Compare(Movie x, Movie y)
        {
            return x.title.CompareTo(y.title);
        }

        #endregion
    }

    public class MovieComparerDatePublishedDescending : IComparer<Movie>
    {
        #region IComparer<Movie> Members

        public int Compare(Movie x, Movie y)
        {
            return y.date_published.CompareTo(x.date_published);
        }

        #endregion
    }

    public class MovieComparerDatePublishedAscending : IComparer<Movie>
    {
        #region IComparer<Movie> Members

        public int Compare(Movie x, Movie y)
        {
            return x.date_published.CompareTo(y.date_published);
        }

        #endregion
    }
}