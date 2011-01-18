using System;

namespace nothinbutdotnetprep.infrastructure.filtering
{
    public class ComparableCriteriaFactory<ItemToFilter, PropertyType> where PropertyType : IComparable<PropertyType>
    {
        public Criteria<ItemToFilter> greater_than(PropertyType value)
        {
            throw new NotImplementedException();
        }

        public Criteria<ItemToFilter> between(PropertyType start, PropertyType end)
        {
            throw new NotImplementedException();
        }
    }
}