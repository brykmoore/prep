namespace prep.matching
{
  public interface IProvideAccessToCreateMatchers<in ItemToMatch, out PropertyType>
  {
    IMatchA<ItemToMatch> create_match_from(IMatchA<PropertyType> attribute_criteria);
  }
}