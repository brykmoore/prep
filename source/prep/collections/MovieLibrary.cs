using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

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
        foreach (var movie in movies)
        {
            yield return movie;
        }
    }

    public void add(Movie movie)
    {
        var matchingTitle = false;

        if (!movies.Contains(movie))
        {
            foreach (var m in movies)
            {
                if (m.title == movie.title)
                {
                    matchingTitle = true;
                }
            }
            if (!matchingTitle)
                movies.Add(movie);
        }

    }
    
    public IEnumerable<Movie> all_movies_published_by_pixar()
    {
        foreach (var movie in movies)
        {
            if (movie.production_studio.Equals(ProductionStudio.Pixar))
            {
                yield return movie;
            }
        }
    }

    public IEnumerable<Movie> all_movies_published_by_pixar_or_disney()
    {
        foreach (var movie in movies)
        {
            if (movie.production_studio.Equals(ProductionStudio.Pixar) || movie.production_studio.Equals(ProductionStudio.Disney))
            {
                yield return movie;
            }
        }
    }

    public IEnumerable<Movie> all_movies_not_published_by_pixar()
    {
        foreach (var movie in movies)
        {
            if (!movie.production_studio.Equals(ProductionStudio.Pixar))
            {
                yield return movie;
            }
        }
    }

    public IEnumerable<Movie> all_movies_published_after(int year)
    {
        foreach (var movie in movies)
        {
            if (movie.date_published.Year > (year))
            {
                yield return movie;
            }
        }
    }

    public IEnumerable<Movie> all_movies_published_between_years(int startingYear, int endingYear)
    {
        foreach (var movie in movies)
        {
            if (movie.date_published.Year >= startingYear && movie.date_published.Year <= endingYear)
            {
                yield return movie;
            }
        }
    }

    public IEnumerable<Movie> all_kid_movies()
    {
        foreach (var movie in movies)
        {
            if (movie.genre.Equals(Genre.kids))
            {
                yield return movie;
            }
        }
    }

    public IEnumerable<Movie> all_action_movies()
    {
        foreach (var movie in movies)
        {
            if (movie.genre.Equals(Genre.action))
            {
                yield return movie;
            }
        }
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
