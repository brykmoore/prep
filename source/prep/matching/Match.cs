using prep.utility;

namespace prep.matching
{
  public class Match<ItemToMatch>
  {
    public static MatchExtensionPoint<ItemToMatch, PropertyType> with<PropertyType>(
      IGetTheValueOfAProperty<ItemToMatch, PropertyType> accessor)

    {
      return new MatchExtensionPoint<ItemToMatch, PropertyType>(accessor);
    }
  }
}