using prep.matching;

namespace prep.collections
{
  public class IsPublishedBy : IMatchA<Movie>
  {
    ProductionStudio studio;

    public IsPublishedBy(ProductionStudio studio)
    {
      this.studio = studio;
    }

    public bool matches(Movie item)
    {
      return item.production_studio == studio;
    }
  }
}