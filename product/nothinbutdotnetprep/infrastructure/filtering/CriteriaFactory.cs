namespace nothinbutdotnetprep.infrastructure.filtering
{
    public interface CriteriaFactory<ItemToFilter, PropertyType>
    {
        Criteria<ItemToFilter> equal_to(PropertyType value);
        Criteria<ItemToFilter> equal_to_any(params PropertyType[] values);
        Criteria<ItemToFilter> create_criteria(Criteria<PropertyType> raw_criteria);
    }
}