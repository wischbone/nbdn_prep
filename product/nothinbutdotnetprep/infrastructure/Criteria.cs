namespace nothinbutdotnetprep.infrastructure
{
    public interface Criteria<T>
    {
        bool matches(T item);
    }
}