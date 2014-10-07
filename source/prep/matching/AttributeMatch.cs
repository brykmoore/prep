using prep.utility;

namespace prep.matching
{
  public class AttributeMatch<ItemToMatch, PropertyType> : IMatchA<ItemToMatch>
  {
    IGetTheValueOfAProperty<ItemToMatch, PropertyType> get_the_value;
    IMatchA<PropertyType> criteria;

    public AttributeMatch(IGetTheValueOfAProperty<ItemToMatch, PropertyType> get_the_value, IMatchA<PropertyType> criteria)
    {
      this.get_the_value = get_the_value;
      this.criteria = criteria;
    }

    public bool matches(ItemToMatch item)
    {
      var value = get_the_value(item);

      return criteria.matches(value);
    }
  }
}