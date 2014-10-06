using System;
using System.Collections.Generic;
using prep.matching;
using prep.utility;

namespace prep.collections
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

    public IEnumerable<Movie> filter(Condition<Movie> criteria)
    {
      return movies.all_items_matching(new ConditionalMatch<Movie>(criteria)); 
    }

    public IEnumerable<Movie> all_movies_published_by_pixar()
    {
      return filter(x => x.production_studio == ProductionStudio.Pixar);
    }

    public IEnumerable<Movie> all_movies_published_by_pixar_or_disney()
    {
      return filter(x => x.production_studio.Equals(ProductionStudio.Pixar) ||
        x.production_studio.Equals(ProductionStudio.Disney));
    }

    public IEnumerable<Movie> all_movies_not_published_by_pixar()
    {
      return filter(x => !x.production_studio.Equals(ProductionStudio.Pixar));
    }

    public IEnumerable<Movie> all_movies_published_after(int year)
    {
      return filter(x => x.date_published.Year > (year));
    }

    public IEnumerable<Movie> all_movies_published_between_years(int starting_year, int ending_year)
    {
        return filter(movie => movie.date_published.Year >= starting_year && movie.date_published.Year <= ending_year);
    }

    public IEnumerable<Movie> all_kid_movies()
    {
      return filter(movie => movie.genre.Equals(Genre.kids));
    }

    public IEnumerable<Movie> all_action_movies()
    {
      return filter(movie =>movie.genre.Equals(Genre.action));
    }

    public IEnumerable<Movie> sort_all_movies_by_title_descending()
    {
      throw new NotImplementedException();
    }

    public IEnumerable<Movie> sort_all_movies_by_title_ascending()
    {
      throw new NotImplementedException();
    }

    public IEnumerable<Movie> sort_all_movies_by_movie_studio_and_year_published()
    {
      throw new NotImplementedException();
    }

    public IEnumerable<Movie> sort_all_movies_by_date_published_descending()
    {
      throw new NotImplementedException();
    }

    public IEnumerable<Movie> sort_all_movies_by_date_published_ascending()
    {
      throw new NotImplementedException();
    }
  }
}
