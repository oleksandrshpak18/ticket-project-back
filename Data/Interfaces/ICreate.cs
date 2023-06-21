namespace ticket_project_back.Data.Interfaces
{
    public interface ICreate<T> where T : class
    {
        public T AddNew(T item);
    }
}
