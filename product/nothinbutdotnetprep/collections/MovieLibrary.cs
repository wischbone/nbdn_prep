using System;
using System.Collections.Generic;
using nothinbutdotnetprep.infrastructure;

namespace nothinbutdotnetprep.collections
{
    public class MovieLibrary
    {
        IList<Movie> movies;

        public MovieLibrary(IList<Movie> list_of_movies)
        {
            this.movies = list_of_movies;
        }

        public IEnumerable<Movie> all_movies()
        {
            return movies.one_at_a_time();
        }

        public void add(Movie movie)
        {
            if (already_contains(movie)) return;

            movies.Add(movie);
        }

        bool already_contains(Movie movie)
        {
            return movies.Contains(movie);
        }

        public IEnumerable<Movie> all_movies_published_by_pixar()
        {
            IList<Movie> ret = new List<Movie>();
            foreach (var m in movies)
            {
                if (m.production_studio == ProductionStudio.Pixar)
                    ret.Add(m);
            }
            return ret;
        }

        public IEnumerable<Movie> all_movies_published_by_pixar_or_disney()
        {
            IList<Movie> ret = new List<Movie>();
            foreach (var m in movies)
            {
                if (m.production_studio == ProductionStudio.Pixar || m.production_studio == ProductionStudio.Disney)
                    ret.Add(m);
            }
            return ret;
        }

        public IEnumerable<Movie> all_movies_not_published_by_pixar()
        {
            IList<Movie> ret = new List<Movie>();
            foreach (var m in movies)
            {
                if (m.production_studio != ProductionStudio.Pixar)
                    ret.Add(m);
            }
            return ret;
        }

        public IEnumerable<Movie> sort_all_movies_by_title_descending
        {
            get
            {
                var comp = new MovieComparerTitleDescending();
                ((List<Movie>) movies).Sort(comp);
                return movies;
            }
        }

        public IEnumerable<Movie> sort_all_movies_by_title_ascending
        {
            get
            {
                var comp = new MovieComparerTitleAscending();
                ((List<Movie>) movies).Sort(comp);
                return movies;
            }
        }

        public IEnumerable<Movie> sort_all_movies_by_movie_studio_and_year_published()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> all_movies_published_after(int year)
        {
            IList<Movie> ret = new List<Movie>();
            foreach (var m in movies)
            {
                if (m.date_published.Year > year)
                    ret.Add(m);
            }
            return ret;
        }

        public IEnumerable<Movie> all_movies_published_between_years(int startingYear, int endingYear)
        {
            IList<Movie> ret = new List<Movie>();
            foreach (var m in movies)
            {
                if (m.date_published.Year >= startingYear && m.date_published.Year <= endingYear)
                    ret.Add(m);
            }
            return ret;
        }

        public IEnumerable<Movie> all_kid_movies()
        {
            IList<Movie> ret = new List<Movie>();
            foreach (var m in movies)
            {
                if (m.genre == Genre.kids)
                    ret.Add(m);
            }
            return ret;
        }

        public IEnumerable<Movie> all_action_movies()
        {
            IList<Movie> ret = new List<Movie>();
            foreach (var m in movies)
            {
                if (m.genre == Genre.action)
                    ret.Add(m);
            }
            return ret;
        }

        public IEnumerable<Movie> sort_all_movies_by_date_published_descending()
        {
            var comp = new MovieComparerDatePublishedDescending();
            ((List<Movie>) movies).Sort(comp);
            return movies;
        }

        public IEnumerable<Movie> sort_all_movies_by_date_published_ascending()
        {
            var comp = new MovieComparerDatePublishedAscending();
            ((List<Movie>) movies).Sort(comp);
            return movies;
        }
    }
}