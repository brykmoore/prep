namespace prep.utility
{
  public delegate PropertyType IGetTheValueOfAProperty<in ItemWithProperty, out PropertyType>(ItemWithProperty item);
}