using System;
using prep.matching;

namespace prep.collections
{
  public class Movie : IEquatable<Movie>
  {
    public string title { get; set; }
    public ProductionStudio production_studio { get; set; }
    public Genre genre { get; set; }
    public int rating { get; set; }
    public DateTime date_published { get; set; }

    public bool Equals(Movie other)
    {
      if (other == null) return false;

      return ReferenceEquals(this, other) || title.Equals(other.title);
    }

    public override bool Equals(object obj)
    {
      return Equals(obj as Movie);
    }

    public override int GetHashCode()
    {
      return title.GetHashCode();
    }

    public static IMatchA<Movie> in_genre(Genre genre)
    {
      return new IsInGenre(genre);
    }

    public static IMatchA<Movie> published_by(ProductionStudio studio)
    {
      return new IsPublishedBy(studio);
    }

    public static IMatchA<Movie> published_by_pixar_or_disney()
    {
      return published_by(ProductionStudio.Pixar)
        .or(published_by(ProductionStudio.Disney));
    }
  }
}