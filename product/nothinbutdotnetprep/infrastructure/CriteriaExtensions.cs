namespace nothinbutdotnetprep.infrastructure
{
    public static class CriteriaExtensions
    {
        public static Criteria<T> or<T>(this Criteria<T> left, Criteria<T> right)
        {
            return new OrCriteria<T>(left, right);
        }
    }
}