namespace ticket_project_back.Data.Interfaces
{
    public interface IGet<T> where T : class
    {
        public IEnumerable<T> GetAll();

        public T GetById(int id);
        public IEnumerable<T> SearchByKeyword(string keyword);
    }
}
