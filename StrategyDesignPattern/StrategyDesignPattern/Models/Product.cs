using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdentityProject.Models
{
    public class Product
    {
        [BsonId] //For MongoDb
        [Key]
        [BsonRepresentation(BsonType.ObjectId)] //For MongoDb
        public string Id { get; set; }

        public string Name { get; set; }

        [BsonRepresentation(BsonType.Decimal128)] //For MongoDb
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public int Stock { get; set; }

        public string UserId { get; set; }

        [BsonRepresentation(BsonType.DateTime)] //For MongoDb
        public DateTime CreatedDate { get; set; }
    }
}