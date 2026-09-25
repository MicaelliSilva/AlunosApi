namespace AlunosApi.Utils
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string AlunoCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}