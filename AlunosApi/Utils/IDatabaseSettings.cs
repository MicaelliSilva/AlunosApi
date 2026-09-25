namespace AlunosApi.Utils
{
    public interface IDatabaseSettings
    {
        string AlunoCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}