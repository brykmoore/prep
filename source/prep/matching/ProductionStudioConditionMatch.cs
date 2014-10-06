using prep.utility;

namespace prep.matching
{
  public class ProductionStudioConditionMatch<ItemToMatch> : IMatchA<ItemToMatch>
  {
    ProductionStudioCondition<ItemToMatch> condition;

    public ProductionStudioConditionMatch(ProductionStudioCondition<ItemToMatch> condition)
    {
      this.condition = condition;
    }

    public  bool matches(ItemToMatch item)
    {
      return condition(item);
    }
  }
}