using AlunosApi.Models.Aluno;
using AlunosApi.Utils;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace AlunosApi.Services
{
    public class AlunoService
    {
        private readonly IMongoCollection<AlunoModel> _alunoCollection;

        public AlunoService(IDatabaseSettings settings)
        {
            var connectionString = new MongoClient(settings.ConnectionString);
            var database = connectionString.GetDatabase(settings.DatabaseName);
            _alunoCollection = database.GetCollection<AlunoModel>(settings.AlunoCollectionName);
        }

        public AlunoModel CreateAluno(AlunoModel aluno)
        {
            _alunoCollection.InsertOne(aluno);
            return aluno;
        }

        public AlunoModel BuscarAluno(string id)
        {
            return _alunoCollection.Find(aluno => aluno.Id == id).FirstOrDefault();
        }

        public List<AlunoModel> BuscarTodos()
        {
            var listaAluno = _alunoCollection.Find(_ => true).ToList();
            return listaAluno;
        }

        public bool DeletarAluno(string id)
        {
            var deletarAluno = _alunoCollection.DeleteOne(aluno => aluno.Id == id);
            if (deletarAluno.DeletedCount > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
