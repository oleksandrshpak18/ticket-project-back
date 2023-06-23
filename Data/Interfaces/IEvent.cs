namespace ticket_project_back.Data.Interfaces
{
    public interface IEvent<T> where T : class
    {
        public IEnumerable<T> GetByPerformerId(int performerId);
        public IEnumerable<T> GetByVenueId(int venueId);
    }
}
