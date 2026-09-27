using AlunosApi.Models.Professor;
using AlunosApi.Utils;
using MongoDB.Driver;

namespace AlunosApi.Services.Professor
{
    public class ProfessorService
    {
        private readonly IMongoCollection<ProfessorModel> _professorCollection;

        public ProfessorService(IDatabaseSettings settings)
        {
            var connectionString = new MongoClient(settings.ConnectionString);
            var database = connectionString.GetDatabase(settings.DatabaseName);
            _professorCollection = database.GetCollection<ProfessorModel>(settings.ProfessorCollectionName);
        }

        public ProfessorModel CadastrarProfessor(ProfessorModel professor)
        {
            _professorCollection.InsertOne(professor);
            return professor;
        }

        public ProfessorModel BuscarProfessor(string id)
        {
            var retorno = _professorCollection.Find(professor => professor.Id == id).FirstOrDefault();
            return retorno;
        }

        public List<ProfessorModel> ListarProfessores()
        {
            var listaProfessor = _professorCollection.Find(_ => true).ToList();
            return listaProfessor;
        }

        public bool DeletarProfessor(string id)
        {
            var deletarProfessor = _professorCollection.DeleteOne(professor => professor.Id == id);

            if (deletarProfessor.DeletedCount > 0)
                return true;
            else
                return false;
        }

        public ProfessorModel AtualizarProfessor(string id, ProfessorModel professor)
        {
            var filter = Builders<ProfessorModel>.Filter.Eq(a => a.Id, id);

            var updateList = new List<UpdateDefinition<ProfessorModel>>();

            if (!string.IsNullOrEmpty(professor.Nome))
                updateList.Add(Builders<ProfessorModel>.Update.Set(a => a.Nome, professor.Nome));

            if (!string.IsNullOrEmpty(professor.Sexo))
                updateList.Add(Builders<ProfessorModel>.Update.Set(a => a.Sexo, professor.Sexo));

            if (!string.IsNullOrEmpty(professor.Email))
                updateList.Add(Builders<ProfessorModel>.Update.Set(a => a.Email, professor.Email));

            var update = Builders<ProfessorModel>.Update.Combine(updateList);

            var options = new FindOneAndUpdateOptions<ProfessorModel>
            {
                ReturnDocument = ReturnDocument.After
            };

            return _professorCollection.FindOneAndUpdate(filter, update, options);
        }
    }
}
