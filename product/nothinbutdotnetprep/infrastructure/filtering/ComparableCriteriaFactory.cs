using System;

namespace nothinbutdotnetprep.infrastructure.filtering
{
    public class ComparableCriteriaFactory<ItemToFilter, PropertyType> : CriteriaFactory<ItemToFilter, PropertyType>
        where PropertyType : IComparable<PropertyType>
    {
        CriteriaFactory<ItemToFilter, PropertyType> original_factory;

        public ComparableCriteriaFactory(CriteriaFactory<ItemToFilter, PropertyType> original_factory)
        {
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
            return create_criteria(new IsGreaterThan<PropertyType>(value));
        }

        public Criteria<ItemToFilter> between(PropertyType start, PropertyType end)
        {
            return create_criteria(new IsBetween<PropertyType>(start, end));
        }

        public Criteria<ItemToFilter> create_criteria(Criteria<PropertyType> raw_criteria)
        {
            return original_factory.create_criteria(raw_criteria);
        }
    }
}