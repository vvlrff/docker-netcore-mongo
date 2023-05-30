namespace dockerForum.Models
{
    public interface IPostStoreDatabaseSettings
    {
        string PostCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
