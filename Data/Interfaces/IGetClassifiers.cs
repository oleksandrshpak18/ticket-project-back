namespace ticket_project_back.Data.Interfaces
{
    public interface IGetClassifiers<T> where T : class
    {
        public IEnumerable<T> GetAllClassifiers();
    }
}
