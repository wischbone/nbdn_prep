using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.filtering
{
    public class DefaultCriteriaFactory<ItemToFilter, PropertyType> : CriteriaFactory<ItemToFilter, PropertyType>
    {
        PropertyAccessor<ItemToFilter, PropertyType> property_accessor;

        public DefaultCriteriaFactory(PropertyAccessor<ItemToFilter, PropertyType> property_accessor)
        {
            this.property_accessor = property_accessor;
        }

        public Criteria<ItemToFilter> equal_to(PropertyType value)
        {
            return equal_to_any(value);
        }

        public Criteria<ItemToFilter> equal_to_any(params PropertyType[] values)
        {
            return
                new AnononymousCriteria<ItemToFilter>(x => new List<PropertyType>(values).Contains(property_accessor(x)));
        }

        public Criteria<ItemToFilter> not_equal_to(PropertyType value)
        {
            return new NotCriteria<ItemToFilter>(equal_to(value));
        }
    }
}