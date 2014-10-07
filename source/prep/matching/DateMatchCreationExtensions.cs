using System;

namespace prep.matching
{
  public static class DateMatchCreationExtensions
  {
    public static IMatchA<ItemToMatch> greater_than<ItemToMatch>(this IProvideAccessToCreateMatchers<ItemToMatch, 
      DateTime> extension_point, int value) 
    {
      return extension_point.create_match_from(
        Match<DateTime>.with(x => x.Year).greater_than(value));
    }
  }
}