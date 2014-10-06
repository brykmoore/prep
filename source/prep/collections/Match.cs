using prep.utility;

namespace prep.collections
{
  public class Match<ItemToMatch>
  {
    public static MatchFactory<ItemToMatch, PropertyType> with<PropertyType>(
      IGetTheValueOfAProperty<ItemToMatch, PropertyType> accessor)
    {
      return new MatchFactory<ItemToMatch, PropertyType>(accessor); 
    }
  }
}