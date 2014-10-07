using System.Collections.Generic;
using prep.matching;

namespace prep.utility
{
  public class FilteringExtensionPoint<ItemToFilter, PropertyType> : ICreateAMatchResult<ItemToFilter,
    PropertyType, IEnumerable<ItemToFilter>>
  {
    IEnumerable<ItemToFilter> items;
    IGetTheValueOfAProperty<ItemToFilter, PropertyType> accessor;

    public FilteringExtensionPoint(IEnumerable<ItemToFilter> items,
      IGetTheValueOfAProperty<ItemToFilter, PropertyType> accessor)
    {
      this.items = items;
      this.accessor = accessor;
    }

    public IEnumerable<ItemToFilter> create_match_result(IMatchA<PropertyType> attribute_criteria)
    {
      return items.all_items_matching(Match<ItemToFilter>.with(accessor).create_match_result(attribute_criteria));
    }

    public IEnumerable<ItemToFilter> create_match_result(Condition<ItemToFilter> condition)
    {
      return items.all_items_matching(condition);
    }

    public ICreateAMatchResult<ItemToFilter, PropertyType, IEnumerable<ItemToFilter>> not
    {
      get { return new NegatingFilteringExtensionPoint(this); }
    }

    class NegatingFilteringExtensionPoint : ICreateAMatchResult<ItemToFilter, PropertyType, IEnumerable<ItemToFilter>>
    {
      ICreateAMatchResult<ItemToFilter, PropertyType, IEnumerable<ItemToFilter>> original;

      public NegatingFilteringExtensionPoint(
        ICreateAMatchResult<ItemToFilter, PropertyType, IEnumerable<ItemToFilter>> original)
      {
        this.original = original;
      }

      public IEnumerable<ItemToFilter> create_match_result(IMatchA<PropertyType> attribute_criteria)
      {
        return original.create_match_result(attribute_criteria.not());
      }

      public IEnumerable<ItemToFilter> create_match_result(Condition<ItemToFilter> condition)
      {
        return original.create_match_result(x => !condition(x));
      }
    }
  }
}