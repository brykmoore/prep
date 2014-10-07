using prep.utility;

namespace prep.matching
{
  public class MatchExtensionPoint<ItemToMatch, PropertyType> : ICreateAMatchResult<ItemToMatch, PropertyType,
    IMatchA<ItemToMatch>>
  {
    IGetTheValueOfAProperty<ItemToMatch, PropertyType> accessor;

    public MatchExtensionPoint(IGetTheValueOfAProperty<ItemToMatch, PropertyType> accessor)
    {
      this.accessor = accessor;
    }

    class NegatedMatchExtensionPoint : ICreateAMatchResult<ItemToMatch, PropertyType, IMatchA<ItemToMatch>>
    {
      ICreateAMatchResult<ItemToMatch, PropertyType,IMatchA<ItemToMatch>> original;

      public NegatedMatchExtensionPoint(ICreateAMatchResult<ItemToMatch, PropertyType, IMatchA<ItemToMatch>> original)
      {
        this.original = original;
      }

      public IMatchA<ItemToMatch> create_match_result(IMatchA<PropertyType> attribute_criteria)
      {
        return original.create_match_result(attribute_criteria).not();
      }

      public IMatchA<ItemToMatch> create_match_result(Condition<ItemToMatch> condition)
      {
        return original.create_match_result(x => !condition(x));
      }
    }

    public ICreateAMatchResult<ItemToMatch, PropertyType,IMatchA<ItemToMatch>> not
    {
      get
      {
        return new NegatedMatchExtensionPoint(this);
      }
    }

    public IMatchA<ItemToMatch> create_match_result(IMatchA<PropertyType> attribute_criteria)
    {
      return new AttributeMatch<ItemToMatch, PropertyType>(accessor, attribute_criteria);
    }

    public IMatchA<ItemToMatch> create_match_result(Condition<ItemToMatch> condition)
    {
      return new ConditionalMatch<ItemToMatch>(condition);
    }
  }
}