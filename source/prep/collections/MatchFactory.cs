using prep.matching;
using prep.utility;

namespace prep.collections
{
  public class MatchFactory<ItemToMatch, PropertyType>
  {
    IGetTheValueOfAProperty<ItemToMatch, PropertyType> accessor;

    public MatchFactory(IGetTheValueOfAProperty<ItemToMatch, PropertyType> accessor)
    {
      this.accessor = accessor;
    }

    public IMatchA<ItemToMatch> equal_to(PropertyType value)
    {
      throw new System.NotImplementedException();
    }
  }
}