using System.Collections.Generic;

namespace prep.sorting
{
  public class ReverseComparer<ItemToCompare> : IComparer<ItemToCompare>
  {
    IComparer<ItemToCompare> original;

    public ReverseComparer(IComparer<ItemToCompare> original)
    {
      this.original = original;
    }

    public int Compare(ItemToCompare x, ItemToCompare y)
    {
      return -original.Compare(x, y);
    }
  }
}