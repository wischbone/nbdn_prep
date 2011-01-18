namespace nothinbutdotnetprep.infrastructure.filtering
{
    public class DefaultCriteriaEntryPoint<ItemToFilter, PropertyType> : CriteriaEntryPoint<ItemToFilter, PropertyType>
    {
        PropertyAccessor<ItemToFilter, PropertyType> accessor;

        public NegatingCriteriaEntryPoint<ItemToFilter, PropertyType> not
        {
            get { return new NegatingCriteriaEntryPoint<ItemToFilter, PropertyType>(this); }
        }

        public DefaultCriteriaEntryPoint(PropertyAccessor<ItemToFilter, PropertyType> accessor)
        {
            this.accessor = accessor;
        }

        public Criteria<ItemToFilter> create_criteria_for(Criteria<PropertyType> criteria)
        {
            return new PropertyCriteria<ItemToFilter, PropertyType>(accessor,
                                                                    criteria);
        }
    }
}