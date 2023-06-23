namespace ticket_project_back.Data.Interfaces
{
    public interface IUpdateDescription<T> where T : class
    {
        public T updateDescription(int id, string newDescr);
    }
}
