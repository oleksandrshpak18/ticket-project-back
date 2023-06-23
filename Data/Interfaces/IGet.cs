namespace ticket_project_back.Data.Interfaces
{
    public interface IGet<T1, T2> 
        where T1 : class
        where T2 : class
    {
        public T1 ConvertToVm(T2 obj);
        public IEnumerable<T2> GetWithRelations();
        public IEnumerable<T1> GetAll();

        public T1 GetById(int id);
        public IEnumerable<T1> SearchByKeyword(string keyword);
    }
}
