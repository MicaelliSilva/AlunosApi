using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AlunosApi.Models.Curso
{
    public class CursoModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonIgnoreIfDefault]
        public string? Id { get; set; }

        public string? Nome  { get; set; }

        public int? CodigoCurso { get; set; } 
    }
}
