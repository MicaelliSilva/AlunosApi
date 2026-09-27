using AlunosApi.Models.Disciplina;
using AlunosApi.Utils;
using MongoDB.Driver;

namespace AlunosApi.Services.Disciplina
{
    public class DisciplinaService
    {
        private readonly IMongoCollection<DisciplinaModel> _disciplinaCollection;

        public DisciplinaService(IDatabaseSettings settings)
        {
            var connectionString = new MongoClient(settings.ConnectionString);
            var database = connectionString.GetDatabase(settings.DatabaseName);
            _disciplinaCollection = database.GetCollection<DisciplinaModel>(settings.DisciplinaCollectionName);
        }

        public DisciplinaModel CadastrarDisciplina(DisciplinaModel disciplina)
        {
            _disciplinaCollection.InsertOne(disciplina);

            return disciplina;
        } 

        public DisciplinaModel BuscarDisciplina(string id)
        {
            var disciplinaEncontrada = _disciplinaCollection.Find(d => d.Id == id ).FirstOrDefault();
            return disciplinaEncontrada;
        }

        public List<DisciplinaModel> ListarDisciplinas()
        {
            var listarDisciplinas = _disciplinaCollection.Find(_ => true).ToList();
            return listarDisciplinas;
        }

        public bool DeletarDisciplina(string id)
        {
            var disciplinaDeletada = _disciplinaCollection.DeleteOne(d => d.Id == id);

            if(disciplinaDeletada.DeletedCount > 0)
                return true;
            else
                return false;
        }

        public DisciplinaModel AtualizarDisciplina(string id, DisciplinaModel disciplina)
        {
            var filter = Builders<DisciplinaModel>.Filter.Eq(d => d.Id, id);

            var updateList = new List<UpdateDefinition<DisciplinaModel>>();

            if (!string.IsNullOrEmpty(disciplina.Nome))
                updateList.Add(Builders<DisciplinaModel>.Update.Set(d => d.Nome, disciplina.Nome));

            if (!string.IsNullOrEmpty(disciplina.IdProfessor))
                updateList.Add(Builders<DisciplinaModel>.Update.Set(d => d.IdProfessor, disciplina.IdProfessor));

            if (disciplina.CodigoCurso.HasValue)
                updateList.Add(Builders<DisciplinaModel>.Update.Set(d => d.CodigoCurso, disciplina.CodigoCurso.Value));

            if (disciplina.CargaHoraria.HasValue)
                updateList.Add(Builders<DisciplinaModel>.Update.Set(d => d.CargaHoraria, disciplina.CargaHoraria.Value));

            var update = Builders<DisciplinaModel>.Update.Combine(updateList);

            var options = new FindOneAndUpdateOptions<DisciplinaModel>
            {
                ReturnDocument = ReturnDocument.After
            };

            return _disciplinaCollection.FindOneAndUpdate(filter, update, options);
        }
    }
}
