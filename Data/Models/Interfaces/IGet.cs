namespace ticket_project_back.Data.Models.Interfaces
{
    public interface IGet<T> where T : class
    {
        public T GetAll();
    }
}
