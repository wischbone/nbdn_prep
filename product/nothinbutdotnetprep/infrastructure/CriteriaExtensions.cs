using System;
using nothinbutdotnetprep.infrastructure.filtering;
using nothinbutdotnetprep.infrastructure.ranges;

namespace nothinbutdotnetprep.infrastructure
{
    public static class CriteriaExtensions
    {
        public static Criteria<T> or<T>(this Criteria<T> left, Criteria<T> right)
        {
            return new OrCriteria<T>(left, right);
        }

        public static Criteria<ItemToFilter> equal_to_any<ItemToFilter, PropertyType>(
            this CriteriaEntryPoint<ItemToFilter, PropertyType> entry_point,
            params PropertyType[] values)
        {
            return create_criteria(entry_point,
                                   new IsEqualToAny<PropertyType>(values));
        }

        public static Criteria<ItemToFilter> equal_to<ItemToFilter, PropertyType>(
            this CriteriaEntryPoint<ItemToFilter, PropertyType> entry_point, PropertyType value)
        {
            return equal_to_any(entry_point, value);
        }

        public static Criteria<ItemToFilter> greater_than<ItemToFilter, PropertyType>(
            this CriteriaEntryPoint<ItemToFilter, PropertyType> entry_point, PropertyType value)
            where PropertyType : IComparable<PropertyType>
        {
            return create_criteria(entry_point, new FallsInRange<PropertyType>(
                                                    new ExclusiveRangeWithNoUpperBound<PropertyType>(value)));
        }

        public static Criteria<ItemToFilter> between<ItemToFilter, PropertyType>(
            this CriteriaEntryPoint<ItemToFilter, PropertyType> entry_point, PropertyType start, PropertyType end)
            where PropertyType : IComparable<PropertyType>
        {
            return create_criteria(entry_point, new FallsInRange<PropertyType>(
                                                    new InclusiveRange<PropertyType>(start, end)));
        }

        public static Criteria<ItemToFilter> create_criteria<ItemToFilter, PropertyType>(
            CriteriaEntryPoint<ItemToFilter, PropertyType> entry_point, Criteria<PropertyType> criteria)
        {
            return entry_point.create_criteria_for(criteria);
        }
    }
}