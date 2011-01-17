using System;

namespace nothinbutdotnetprep.infrastructure
{
    public class AnononymousCriteria<T> : Criteria<T>
    {
        Predicate<T> condition;

        public AnononymousCriteria(Predicate<T> condition)
        {
            this.condition = condition;
        }

        public bool matches(T item)
        {
            return condition(item);
        }
    }
}