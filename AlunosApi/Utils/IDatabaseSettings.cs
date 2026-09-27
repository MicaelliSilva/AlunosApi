namespace AlunosApi.Utils
{
    public interface IDatabaseSettings
    {
        string AlunoCollectionName { get; set; }
        public string DisciplinaCollectionName { get; set; }
        public string CursoCollectionName { get; set; }
        public string ProfessorCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}