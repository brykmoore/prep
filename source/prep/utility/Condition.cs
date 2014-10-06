using prep.collections;

namespace prep.utility
{
  public delegate bool Condition<in T>(T item);
  public delegate ProductionStudio ProductionStudioCondition<in T>(T item);
}