using prep.matching;

namespace prep.collections
{
  public interface ICreateMatchers<in ItemToMatch, in PropertyType>
  {
    IMatchA<ItemToMatch> equal_to(params PropertyType[] values);
    IMatchA<ItemToMatch> not_equal_to(PropertyType value);
  }
}