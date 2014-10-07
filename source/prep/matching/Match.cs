using prep.utility;

namespace prep.matching
{
  public class Match<ItemToMatch>
  {
    public static MatchCreationExtensionPoint<ItemToMatch, PropertyType> with<PropertyType>(
      IGetTheValueOfAProperty<ItemToMatch, PropertyType> accessor)

    {
      return new MatchCreationExtensionPoint<ItemToMatch, PropertyType>(accessor);
    }
  }
}