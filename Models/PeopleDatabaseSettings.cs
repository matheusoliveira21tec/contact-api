namespace contact_api.Models
{
    public class PeopleDatabaseSettings
    {
        public string ConnectionString { get; set; } = null;
        public string DatabaseName { get; set; } = null;
        public string PeopleCollectionName { get; set; } = null;
    }
}