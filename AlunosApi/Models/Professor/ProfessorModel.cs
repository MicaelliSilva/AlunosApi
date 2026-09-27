using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AlunosApi.Models.Professor
{
    public class ProfessorModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonIgnoreIfDefault]
        public string? Id { get; set; }

        public string? Nome { get; set; }

        public string? Sexo { get; set; }

        public string? Email { get; set; }
    }
}
