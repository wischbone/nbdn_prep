namespace nothinbutdotnetprep.infrastructure
{
    public class AnononymousCriteria<T> : Criteria<T>
    {
        Condition<T> condition;

        public AnononymousCriteria(Condition<T> condition)
        {
            this.condition = condition;
        }

        public bool matches(T item)
        {
            return condition(item);
        }
    }
}