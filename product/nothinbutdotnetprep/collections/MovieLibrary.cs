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
            return all_movies_matching(x => x.production_studio == ProductionStudio.Pixar);
        }

        IEnumerable<Movie> all_movies_matching(Predicate<Movie> condition)
        {
            foreach (var movie in movies)
            {
                if (condition(movie))yield return movie;
            }
        }

        public IEnumerable<Movie> all_movies_published_by_pixar_or_disney()
        {
            return
                all_movies_matching(
                    x => x.production_studio == ProductionStudio.Disney || x.production_studio == ProductionStudio.Pixar);
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
            return all_movies_matching(x => x.date_published.Year > year);
        }

        public IEnumerable<Movie> all_movies_published_between_years(int startingYear, int endingYear)
        {
            return all_movies_matching(m => m.date_published.Year >= startingYear && m.date_published.Year <= endingYear);
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

        private IEnumerable<Movie> all_movies_produced_by(ProductionStudio studio)
        {
            return all_movies_matching(x => x.production_studio == studio);
        }


    }
}