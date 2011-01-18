namespace nothinbutdotnetprep.infrastructure
{
    public class IsEqualTo<T> : Criteria<T>
    {
        T value_to_equal;

        public IsEqualTo(T value_to_equal)
        {
            this.value_to_equal = value_to_equal;
        }

        public bool matches(T item)
        {
            return item.Equals(value_to_equal);
        }
    }
}