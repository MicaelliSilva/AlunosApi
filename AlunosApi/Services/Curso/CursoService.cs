using AlunosApi.Models.Curso;
using AlunosApi.Utils;
using MongoDB.Driver;

namespace AlunosApi.Services.Curso
{
    public class CursoService
    {
        private readonly IMongoCollection<CursoModel> _cursoCollection;

        public CursoService(IDatabaseSettings settings)
        {
            var connectionString = new MongoClient(settings.ConnectionString);
            var database = connectionString.GetDatabase(settings.DatabaseName);
            _cursoCollection = database.GetCollection<CursoModel>(settings.CursoCollectionName);
        }

        public CursoModel CadastrarCurso(CursoModel curso)
        {
            _cursoCollection.InsertOne(curso);

            return curso;
        }

        public CursoModel BuscarCurso(string id)
        {
            var cursoEncontrado = _cursoCollection.Find(d => d.Id == id).FirstOrDefault();
            return cursoEncontrado;
        }

        public List<CursoModel> ListarCursos()
        {
            var listarCursos = _cursoCollection.Find(_ => true).ToList();
            return listarCursos;
        }

        public bool DeletarCurso(string id)
        {
            var cursoDeletado = _cursoCollection.DeleteOne(d => d.Id == id);

            if (cursoDeletado.DeletedCount > 0)
                return true;
            else
                return false;
        }

        public CursoModel AtualizarCurso(string id, CursoModel curso)
        {
            var filter = Builders<CursoModel>.Filter.Eq(d => d.Id, id);

            var updateList = new List<UpdateDefinition<CursoModel>>();

            if (!string.IsNullOrEmpty(curso.Nome))
                updateList.Add(Builders<CursoModel>.Update.Set(d => d.Nome, curso.Nome));

            if (curso.CodigoCurso.HasValue)
                updateList.Add(Builders<CursoModel>.Update.Set(d => d.CodigoCurso, curso.CodigoCurso.Value));

            var update = Builders<CursoModel>.Update.Combine(updateList);

            var options = new FindOneAndUpdateOptions<CursoModel>
            {
                ReturnDocument = ReturnDocument.After
            };

            return _cursoCollection.FindOneAndUpdate(filter, update, options);
        }
    }
}
