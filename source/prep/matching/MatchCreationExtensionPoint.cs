using prep.utility;

namespace prep.matching
{
  public class MatchCreationExtensionPoint<ItemToMatch, PropertyType> : IProvideAccessToCreateMatchers<ItemToMatch, PropertyType>
  {
    IGetTheValueOfAProperty<ItemToMatch, PropertyType> accessor;

    public MatchCreationExtensionPoint(IGetTheValueOfAProperty<ItemToMatch, PropertyType> accessor)
    {
      this.accessor = accessor;
    }

    class NegatedExtensionPoint : IProvideAccessToCreateMatchers<ItemToMatch, PropertyType>
    {
      IProvideAccessToCreateMatchers<ItemToMatch, PropertyType> original;

      public NegatedExtensionPoint(IProvideAccessToCreateMatchers<ItemToMatch, PropertyType> original)
      {
        this.original = original;
      }

      public IMatchA<ItemToMatch> create_match_from(IMatchA<PropertyType> attribute_criteria)
      {
        return original.create_match_from(attribute_criteria).not();
      }
    }

    public IProvideAccessToCreateMatchers<ItemToMatch, PropertyType> not
    {
      get
      {
        return new NegatedExtensionPoint(this);
      }
    }

    public IMatchA<ItemToMatch> create_match_from(IMatchA<PropertyType> attribute_criteria)
    {
      return new AttributeMatch<ItemToMatch, PropertyType>(accessor, attribute_criteria);
    }
  }
}