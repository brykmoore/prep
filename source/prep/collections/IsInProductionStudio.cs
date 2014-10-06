using prep.matching;

namespace prep.collections
{
  public class IsInProductionStudio : IMatchA<Movie>
  {
      ProductionStudio studio;

    public IsInProductionStudio(ProductionStudio studio)
    {
        this.studio = studio;
    }

    public bool matches(Movie item)
    {
        return item.production_studio == studio;
    }

    public bool equal_to(ProductionStudio item)
    {
        return studio == item;
    } 
  }
}