namespace ticket_project_back.Data.Interfaces
{
    public interface IUpdateImage<T> where T : class
    {
        public T updateImage(int id, string imageUrl);
    }
}
