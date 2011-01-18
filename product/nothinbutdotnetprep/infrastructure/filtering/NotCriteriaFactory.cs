using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nothinbutdotnetprep.infrastructure.filtering
{

    public class NotCriteriaFactory<ItemToFilter, PropertyType> : CriteriaFactory<ItemToFilter, PropertyType>
    {
        CriteriaFactory<ItemToFilter, PropertyType> original_factory;

        public NotCriteriaFactory(CriteriaFactory<ItemToFilter, PropertyType> original_factory)
        {
            this.original_factory = original_factory;
        }

        public Criteria<ItemToFilter> equal_to(PropertyType value)
        {
            return original_factory.not_equal_to(value);
        }

        public Criteria<ItemToFilter> equal_to_any(params PropertyType[] values)
        {
            return original_factory.equal_to_any(values);
        }

        public Criteria<ItemToFilter> not_equal_to(PropertyType value)
        {
            return original_factory.equal_to(value);
        }

        public Criteria<ItemToFilter> create_criteria(Criteria<PropertyType> raw_criteria)
        {
            return original_factory.create_criteria(raw_criteria);
        }
    }
}
