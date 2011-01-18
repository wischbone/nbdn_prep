using System;

namespace nothinbutdotnetprep.infrastructure.filtering
{
    public class ComparableCriteriaFactory<ItemToFilter, PropertyType>  : CriteriaFactory<ItemToFilter,PropertyType>where PropertyType : IComparable<PropertyType>
    {
        PropertyAccessor<ItemToFilter, PropertyType> accessor;
        CriteriaFactory<ItemToFilter, PropertyType> original_factory;

        public ComparableCriteriaFactory(PropertyAccessor<ItemToFilter, PropertyType> accessor, CriteriaFactory<ItemToFilter, PropertyType> original_factory)
        {
            this.accessor = accessor;
            this.original_factory = original_factory;
        }

        public Criteria<ItemToFilter> equal_to(PropertyType value)
        {
            return original_factory.equal_to(value);
        }

        public Criteria<ItemToFilter> equal_to_any(params PropertyType[] values)
        {
            return original_factory.equal_to_any(values);
        }

        public Criteria<ItemToFilter> not_equal_to(PropertyType value)
        {
            return original_factory.not_equal_to(value);
        }

        public Criteria<ItemToFilter> greater_than(PropertyType value)
        {
            return CreateCriteria(x => accessor(x).CompareTo(value) > 0);
        }

        public Criteria<ItemToFilter> between(PropertyType start, PropertyType end)
        {
            return CreateCriteria(x => accessor(x).CompareTo(start) >= 0 &&
                accessor(x).CompareTo(end) <= 0);
        }

        public Criteria<ItemToFilter> CreateCriteria(Predicate<ItemToFilter> expression)
        {
            return original_factory.CreateCriteria(expression);
        }
    }
}