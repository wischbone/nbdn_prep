using System;

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
            return create_criteria(new IsEqualToAny<PropertyType>(values));
        }

        public NotCriteriaFactory<ItemToFilter, PropertyType> not
        {
            get { return new NotCriteriaFactory<ItemToFilter, PropertyType>(property_accessor); }          
        }

        public Criteria<ItemToFilter> not_equal_to(PropertyType value)
        {
            return new NotCriteria<ItemToFilter>(equal_to(value));
        }

        public Criteria<ItemToFilter> create_criteria(Criteria<PropertyType> criteria)
        {
            return new PropertyCriteria<ItemToFilter, PropertyType>(property_accessor,
                                                                    criteria);
        }
    }
}