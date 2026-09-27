namespace AlunosApi.Utils
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string AlunoCollectionName { get; set; }
        public string DisciplinaCollectionName { get; set; }
        public string CursoCollectionName { get; set; }
        public string ProfessorCollectionName {  get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}