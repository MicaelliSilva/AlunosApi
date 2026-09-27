using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AlunosApi.Models.Disciplina
{
    public class DisciplinaModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonIgnoreIfDefault]
        public string? Id { get; set; }

        public string? Nome { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string? IdProfessor { get; set; }

        public int? CodigoCurso { get; set; }

        public int? CargaHoraria { get; set; }
    }
}
