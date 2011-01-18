namespace nothinbutdotnetprep.infrastructure.filtering
{
    public class Where<ItemToFilter>
    {
        public static DefaultCriteriaEntryPoint<ItemToFilter, PropertyType> has_a<PropertyType>(
            PropertyAccessor<ItemToFilter, PropertyType> accessor)
        {
            return new DefaultCriteriaEntryPoint<ItemToFilter, PropertyType>(accessor);
        }
    }
}