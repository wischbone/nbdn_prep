namespace nothinbutdotnetprep.infrastructure.filtering
{
    public interface CriteriaEntryPoint<ItemToFilter, PropertyType>
    {
        Criteria<ItemToFilter> create_criteria_for(Criteria<PropertyType> criteria);
    }
}