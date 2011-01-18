using System;

namespace nothinbutdotnetprep.infrastructure.filtering
{
    public class Where<ItemToFilter>
    {
        public static ComparableCriteriaFactory<ItemToFilter, PropertyType> has_an<PropertyType>(
            PropertyAccessor<ItemToFilter, PropertyType> accessor) where PropertyType : IComparable<PropertyType>
        {
            return new ComparableCriteriaFactory<ItemToFilter, PropertyType>();
        }

        public static CriteriaFactory<ItemToFilter, PropertyType> has_a<PropertyType>(
            PropertyAccessor<ItemToFilter, PropertyType> accessor)
        {
            return new CriteriaFactory<ItemToFilter, PropertyType>(accessor);
        }
    }
}