using AlunosApi.Models.Aluno;
using AlunosApi.Utils;
using MongoDB.Driver;

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

        public AlunoModel? UpdateAluno(string id, AlunoModel aluno)
        {
            // Filtro pelo ID
            var filter = Builders<AlunoModel>.Filter.Eq(a => a.Id, id);

            // Criação da lista de atualizações dinâmicas
            var updateList = new List<UpdateDefinition<AlunoModel>>();

            if (!string.IsNullOrEmpty(aluno.Nome))
                updateList.Add(Builders<AlunoModel>.Update.Set(a => a.Nome, aluno.Nome));

            if (aluno.Idade.HasValue)
                updateList.Add(Builders<AlunoModel>.Update.Set(a => a.Idade, aluno.Idade.Value));

            if (!string.IsNullOrEmpty(aluno.Sexo))
                updateList.Add(Builders<AlunoModel>.Update.Set(a => a.Sexo, aluno.Sexo));

            if (!string.IsNullOrEmpty(aluno.Email))
                updateList.Add(Builders<AlunoModel>.Update.Set(a => a.Email, aluno.Email));

            if(aluno.Status != null)
                updateList.Add(Builders<AlunoModel>.Update.Set(a => a.Status, aluno.Status));
           
            // Combina todas as atualizações em uma só
            var update = Builders<AlunoModel>.Update.Combine(updateList);

            // Retornar o documento ATUALIZADO
            var options = new FindOneAndUpdateOptions<AlunoModel>
            {
                ReturnDocument = ReturnDocument.After
            };

            return _alunoCollection.FindOneAndUpdate(filter, update, options);
        }
    }
}
