using prep.utility;

namespace prep.matching
{
  public interface ICreateAMatchResult<out ItemToMatch, out PropertyType, out ReturnType>
  {
    ReturnType create_match_result(IMatchA<PropertyType> attribute_criteria);
    ReturnType create_match_result(Condition<ItemToMatch> condition);
  }
}