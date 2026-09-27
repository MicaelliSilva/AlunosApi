using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AlunosApi.Models.Aluno
{
    public class AlunoModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonIgnoreIfDefault] 
        public string? Id { get; set; }

        public string? Nome { get; set; }

        public int? Idade { get; set; }

        public string? Sexo { get; set; }  

        public string? Email { get; set; }

        public StatusEnum? Status {  get; set; }

        public AlunoModel(string id, string nome, int idade, string sexo, string email, StatusEnum status)
        {
            Id = id;
            Nome = nome;
            Idade = idade;
            Sexo = sexo;
            Email = email;
            Status = status;
        }

        public AlunoModel() { }
    }
}
