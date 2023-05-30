namespace dockerForum.Models
{
    public class PostStoreDatabaseSettings: IPostStoreDatabaseSettings
    {
        public string PostCollectionName { get; set; } = String.Empty;
        public string ConnectionString { get; set; } = String.Empty;
        public string DatabaseName { get; set; } = String.Empty;
    }
}
