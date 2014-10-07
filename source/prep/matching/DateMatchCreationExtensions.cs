using System;

namespace prep.matching
{
  public static class DateMatchCreationExtensions
  {
    public static ReturnType greater_than<ItemToMatch, ReturnType>(this ICreateAMatchResult<ItemToMatch,DateTime,ReturnType> extension_point, int value) 
    {
      return extension_point.create_match_result(Match<DateTime>.with(x => x.Year).greater_than(value));
    }
  }
}