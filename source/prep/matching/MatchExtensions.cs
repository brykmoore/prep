﻿namespace prep.matching
{
  public static class MatchExtensions
  {
    public static IMatchA<ItemToMatch> or<ItemToMatch>(this IMatchA<ItemToMatch> left, IMatchA<ItemToMatch> right)
    {
      return new OrMatch<ItemToMatch>(left, right);
    }

    public static IMatchA<ItemToMatch> not<ItemToMatch>(this IMatchA<ItemToMatch> to_negate)
    {
      return new NegatingMatch<ItemToMatch>(to_negate);
    }
  }
}