namespace nothinbutdotnetprep.infrastructure.filtering
{
    public class NegatingCriteriaEntryPoint<ItemToFilter, PropertyType> : CriteriaEntryPoint<ItemToFilter, PropertyType>
    {
        CriteriaEntryPoint<ItemToFilter, PropertyType> original;

        public NegatingCriteriaEntryPoint(CriteriaEntryPoint<ItemToFilter, PropertyType> original)
        {
            this.original = original;
        }

        public Criteria<ItemToFilter> create_criteria_for(Criteria<PropertyType> criteria)
        {
            return new NotCriteria<ItemToFilter>(original.create_criteria_for(criteria));
        }
    }
}